using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
[RequireComponent(typeof(ARAnchorManager))]

public class ReferencePointManager : MonoBehaviour
{
    private ARRaycastManager aRRaycastManager;
    private ARAnchorManager aRAnchorManager;

    private List<ARAnchor> anchorPoints = new List<ARAnchor>();
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private Touch touch;

    void Awake()
    {
        aRRaycastManager = GetComponent<ARRaycastManager>();
        aRAnchorManager = GetComponent<ARAnchorManager>();
    }

    void Update()
    {
        if (Input.touchCount == 0)
            return;

        touch = Input.GetTouch(0);

        if (touch.phase != TouchPhase.Began)
            return;

        if (aRRaycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = hits[0].pose;
            ARAnchor anchorPoint = aRAnchorManager.AddAnchor(hitPose);
            
            hitPose.position = new Vector3(hitPose.position.x - 5, hitPose.position.y, hitPose.position.z + 10);
            ARAnchor anchorPointTwo = aRAnchorManager.AddAnchor(hitPose);

            hitPose = hits[0].pose;
            hitPose.position = new Vector3(hitPose.position.x + 5, hitPose.position.y, hitPose.position.z - 10);
            ARAnchor anchorPointThree = aRAnchorManager.AddAnchor(hitPose);

            hitPose = hits[0].pose;
            hitPose.position = new Vector3(hitPose.position.x - 5, hitPose.position.y, hitPose.position.z - 10);
            ARAnchor anchorPointFour = aRAnchorManager.AddAnchor(hitPose);

            hitPose = hits[0].pose;
            hitPose.position = new Vector3(hitPose.position.x + 5, hitPose.position.y, hitPose.position.z + 10);
            ARAnchor anchorPointFive = aRAnchorManager.AddAnchor(hitPose);

            if (anchorPoint == null)
            {
                string errorEntry = "Error creating anchor point";
                Debug.Log(errorEntry);
                //debugLog.text += errorEntry;
            }
            else
            {
                anchorPoints.Add(anchorPoint);
                anchorPoints.Add(anchorPointTwo);
                anchorPoints.Add(anchorPointThree);
                anchorPoints.Add(anchorPointFour);
                anchorPoints.Add(anchorPointFive);
                //referencePointCount.text = $"Reference Point Count: {anchorPoints.Count}";
            }
        }

    }

}