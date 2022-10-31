using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARAnchorManager))]
[RequireComponent(typeof(ARRaycastManager))]
public class AnchorCreator : MonoBehaviour
{
    [SerializeField]
    GameObject Prefab, ResetAnchorButton, placementIndicator;

    [SerializeField]
    GameStateController GameStateController;

    List<ARRaycastHit> Hits = new List<ARRaycastHit>();

    List<ARAnchor> Anchors = new List<ARAnchor>();

    ARRaycastManager RaycastManager;

    ARAnchorManager AnchorManager;

    bool PlacementAllowed;

    public GameObject prefab
    {
        get => Prefab;
        set => Prefab = value;
    }

    DebugController debugLog;
    //public GameObject placementIndicator;
    private Pose placementPose;
    private bool placementPoseIsValid = false;

    void Awake()
    {
        debugLog = GameObject.Find("DebugController").GetComponent<DebugController>();
        RaycastManager = GetComponent<ARRaycastManager>();
        AnchorManager = GetComponent<ARAnchorManager>();

        PlacementAllowed = false;
    }

    void Update()
    {
        if (!PlacementAllowed)
            return;

        UpdatePlacementPose();
        UpdatePlacementIndicator();

        var touch = Input.GetTouch(0);
        if (placementPoseIsValid && (Input.touchCount > 0) && (touch.phase == TouchPhase.Began))
        {
            /*
            if (Input.touchCount == 0)
                return;

            var touch = Input.GetTouch(0);
            if (touch.phase != TouchPhase.Began)
                return;
            */

            // Perform the raycast
            if (RaycastManager.Raycast(touch.position, Hits, TrackableType.PlaneWithinPolygon))
            {
                // Raycast hits are sorted by distance, so the first one will be the closest hit.
                var hit = Hits[0];

                // Create a new anchor
                var anchor = CreateAnchor(hit);
                if (anchor)
                {
                    // Remember the anchor so we can remove it later.
                    Anchors.Add(anchor);
                    // Disable placement so only one plant model is placed
                    PlacementAllowed = false;
                    // Now that plant is placed, activate reset button in case player needs to move the plant
                    ResetAnchorButton.SetActive(true);

                    if (!GameStateController.GameStateOne)
                    {
                        GameStateController.GameStateOne = true;
                    }
                }
            }
        }
    }

    ARAnchor CreateAnchor(in ARRaycastHit hit)
    {
        ARAnchor anchor = null;

        // If we hit a plane, try to "attach" the anchor to the plane
        if (hit.trackable is ARPlane plane)
        {
            var planeManager = GetComponent<ARPlaneManager>();
            if (planeManager)
            {
                var oldPrefab = AnchorManager.anchorPrefab;
                AnchorManager.anchorPrefab = prefab;
                anchor = AnchorManager.AttachAnchor(plane, placementPose);
                AnchorManager.anchorPrefab = oldPrefab;
                placementIndicator.SetActive(false); //
                return anchor;
            }
        }

        return null;
    }

    public void RemoveAllAnchors()
    {
        foreach (var anchor in Anchors)
        {
            Destroy(anchor.gameObject);
        }
        Anchors.Clear();
    }

    public void SetPlacementAllowed(bool value)
    {
        PlacementAllowed = value;
    }

    private void UpdatePlacementPose()
    {
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        RaycastManager.Raycast(screenCenter, hits, TrackableType.PlaneWithinPolygon);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
        {
            //debugLog.NewLineDebugText("Placement Pose Valid");
            
            placementPose = hits[0].pose;
            
            var cameraForward = Camera.current.transform.forward;
            var cameraBearing = new Vector3(-cameraForward.x, 0, -cameraForward.z).normalized;
            placementPose.rotation = Quaternion.LookRotation(cameraBearing);
        }
    }

    private void UpdatePlacementIndicator()
    {
        if (placementPoseIsValid)
        {
            //debugLog.NewLineDebugText("Placement Indicator Active");
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }

    public void ResetIntroShapes()
    {
        foreach (GameObject gameObj in FindObjectsOfType<GameObject>(true))
        {
            if (gameObj.CompareTag("Intro Shape"))
            {
                if (gameObj.name == "Intro Cube")
                    gameObj.GetComponent<Renderer>().material.color = new Color(1.0f, 0.0f, 0.0f);
                else if (gameObj.name == "Intro Sphere")
                    gameObj.GetComponent<Renderer>().material.color = new Color(0.08370414f, 0.764623f, 0.9339623f);
                else if (gameObj.name == "Intro Cylinder")
                    gameObj.GetComponent<Renderer>().material.color = new Color(0.0f, 1.0f, 0.009963274f);

                gameObj.SetActive(true);
                gameObj.transform.parent.gameObject.SetActive(false);
            }
        }
    }
}
