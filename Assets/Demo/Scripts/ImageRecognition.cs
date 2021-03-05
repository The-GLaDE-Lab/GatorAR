using System;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARTrackedImageManager))]
public class ImageRecognition : MonoBehaviour
{
    [Serializable]
    struct NamedPrefab
    {
        // System.Guid isn't serializable, so we store the Guid as a string. At runtime, this is converted back to a System.Guid
        public string imageGuid;
        public GameObject imagePrefab;

        public NamedPrefab(Guid guid, GameObject prefab)
        {
            imageGuid = guid.ToString();
            imagePrefab = prefab;
        }
    }

    [SerializeField]
    [HideInInspector]
    List<NamedPrefab> PrefabsList = new List<NamedPrefab>();

    Dictionary<Guid, GameObject> PrefabsDictionary = new Dictionary<Guid, GameObject>();
    Dictionary<Guid, GameObject> Instantiated = new Dictionary<Guid, GameObject>();

    private ARTrackedImageManager aRTrackedImageManager;

    [SerializeField]
    [Tooltip("Reference Image Library")]
    XRReferenceImageLibrary ImageLibrary;

    /// <summary>
    /// Get the <c>XRReferenceImageLibrary</c>
    /// </summary>
    public XRReferenceImageLibrary imageLibrary
    {
        get => ImageLibrary;
        set => ImageLibrary = value;
    }

    public void OnBeforeSerialize()
    {
        PrefabsList.Clear();
        foreach (var kvp in PrefabsDictionary)
        {
            PrefabsList.Add(new NamedPrefab(kvp.Key, kvp.Value));
        }
    }

    public void OnAfterDeserialize()
    {
        PrefabsDictionary = new Dictionary<Guid, GameObject>();
        foreach (var entry in PrefabsList)
        {
            PrefabsDictionary.Add(Guid.Parse(entry.imageGuid), entry.imagePrefab);
        }
    }

    private void Awake()
    {
        aRTrackedImageManager = GetComponent<ARTrackedImageManager>();
    }

    private void OnEnable()
    {
        aRTrackedImageManager.trackedImagesChanged += OnImageChanged;
    }

    private void OnDisable()
    {
        aRTrackedImageManager.trackedImagesChanged -= OnImageChanged;
    }

    private void OnImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
            var minLocalScalar = Mathf.Min(trackedImage.size.x, trackedImage.size.y) / 2;
            trackedImage.transform.localScale = new Vector3(minLocalScalar, minLocalScalar, minLocalScalar);
            UpdateARImage(trackedImage);
        }

        //foreach (ARTrackedImage trackedImage in eventArgs.updated)
        //{
        //    UpdateARImage(trackedImage);
        //}

        //foreach (var trackedImage in args.added)
        //{
        //    Debug.Log(trackedImage.name);
        //}
    }

    private void UpdateARImage(ARTrackedImage trackedImage)
    {
        if (PrefabsDictionary.TryGetValue(trackedImage.referenceImage.guid, out var prefab))
            Instantiated[trackedImage.referenceImage.guid] = Instantiate(prefab, trackedImage.transform);

        //trackedImage.transform.Rotate(90.0f, 0.0f, 0.0f, Space.Self);
        //trackedImage.transform.position = new Vector3(0.01f, transform.position.y, transform.position.z);
    }

    public GameObject GetPrefabForReferenceImage(XRReferenceImage referenceImage)
            => PrefabsDictionary.TryGetValue(referenceImage.guid, out var prefab) ? prefab : null;

    public void SetPrefabForReferenceImage(XRReferenceImage referenceImage, GameObject alternativePrefab)
    {
        PrefabsDictionary[referenceImage.guid] = alternativePrefab;
        if (Instantiated.TryGetValue(referenceImage.guid, out var instantiatedPrefab))
        {
            Instantiated[referenceImage.guid] = Instantiate(alternativePrefab, instantiatedPrefab.transform.parent);
            Destroy(instantiatedPrefab);
        }
    }

#if UNITY_EDITOR
    /// <summary>
    /// This customizes the inspector component and updates the prefab list when
    /// the reference image library is changed.
    /// </summary>
    [CustomEditor(typeof(ImageRecognition))]
    class PrefabImagePairManagerInspector : Editor
    {
        List<XRReferenceImage> m_ReferenceImages = new List<XRReferenceImage>();
        bool m_IsExpanded = true;

        bool HasLibraryChanged(XRReferenceImageLibrary library)
        {
            if (library == null)
                return m_ReferenceImages.Count == 0;

            if (m_ReferenceImages.Count != library.count)
                return true;

            for (int i = 0; i < library.count; i++)
            {
                if (m_ReferenceImages[i] != library[i])
                    return true;
            }

            return false;
        }

        public override void OnInspectorGUI()
        {
            //customized inspector
            var behaviour = serializedObject.targetObject as ImageRecognition;

            serializedObject.Update();
            using (new EditorGUI.DisabledScope(true))
            {
                EditorGUILayout.PropertyField(serializedObject.FindProperty("m_Script"));
            }

            var libraryProperty = serializedObject.FindProperty(nameof(ImageLibrary));
            EditorGUILayout.PropertyField(libraryProperty);
            var library = libraryProperty.objectReferenceValue as XRReferenceImageLibrary;

            //check library changes
            if (HasLibraryChanged(library))
            {
                if (library)
                {
                    var tempDictionary = new Dictionary<Guid, GameObject>();
                    foreach (var referenceImage in library)
                    {
                        tempDictionary.Add(referenceImage.guid, behaviour.GetPrefabForReferenceImage(referenceImage));
                    }
                    behaviour.PrefabsDictionary = tempDictionary;
                }
            }

            // update current
            m_ReferenceImages.Clear();
            if (library)
            {
                foreach (var referenceImage in library)
                {
                    m_ReferenceImages.Add(referenceImage);
                }
            }

            //show prefab list
            m_IsExpanded = EditorGUILayout.Foldout(m_IsExpanded, "Prefab List");
            if (m_IsExpanded)
            {
                using (new EditorGUI.IndentLevelScope())
                {
                    EditorGUI.BeginChangeCheck();

                    var tempDictionary = new Dictionary<Guid, GameObject>();
                    foreach (var image in library)
                    {
                        var prefab = (GameObject)EditorGUILayout.ObjectField(image.name, behaviour.PrefabsDictionary[image.guid], typeof(GameObject), false);
                        tempDictionary.Add(image.guid, prefab);
                    }

                    if (EditorGUI.EndChangeCheck())
                    {
                        Undo.RecordObject(target, "Update Prefab");
                        behaviour.PrefabsDictionary = tempDictionary;
                        EditorUtility.SetDirty(target);
                    }
                }
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
#endif
}
