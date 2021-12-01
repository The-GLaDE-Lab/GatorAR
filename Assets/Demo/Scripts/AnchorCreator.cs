using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARAnchorManager))]
[RequireComponent(typeof(ARRaycastManager))]
public class AnchorCreator : MonoBehaviour
{
    [SerializeField]
    GameObject Prefab, ResetAnchorButton;

    [SerializeField]
    GameStateController GameStateController;

    static List<ARRaycastHit> Hits = new List<ARRaycastHit>();

    List<ARAnchor> Anchors = new List<ARAnchor>();

    ARRaycastManager RaycastManager;

    ARAnchorManager AnchorManager;

    bool PlacementAllowed;

    public GameObject prefab
    {
        get => Prefab;
        set => Prefab = value;
    }

    void Awake()
    {
        RaycastManager = GetComponent<ARRaycastManager>();
        AnchorManager = GetComponent<ARAnchorManager>();

        PlacementAllowed = false;
    }

    void Update()
    {
        if (PlacementAllowed)
        {
            if (Input.touchCount == 0)
                return;

            var touch = Input.GetTouch(0);
            if (touch.phase != TouchPhase.Began)
                return;

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
                anchor = AnchorManager.AttachAnchor(plane, hit.pose);
                AnchorManager.anchorPrefab = oldPrefab;
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
}
