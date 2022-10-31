using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceContent : MonoBehaviour
{

    public ARRaycastManager raycastManager;
    public GraphicRaycaster raycaster;
    public GameObject objectToPlace;

    private void Update() {

        if (Input.GetKeyDown(KeyCode.B))
        {
            Instantiate(objectToPlace, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
        }
        //if (Input.GetMouseButtonDown(0) && !IsClickOverUI()) {
        /*if (Input.GetTouch(0).phase == TouchPhase.Began && !IsClickOverUI()) {

            List<ARRaycastHit> hitPoints = new List<ARRaycastHit>();
            raycastManager.Raycast(Input.mousePosition, hitPoints, TrackableType.PlaneWithinPolygon);

            if (hitPoints.Count > 0) {
                //transform.GetChild(0).gameObject.SetActive(true);
                Pose pose = hitPoints[0].pose;
                Instantiate(objectToPlace, pose.position, pose.rotation);
                //transform.rotation = pose.rotation;
                //transform.position = pose.position;
            }
        }*/
    }

    bool IsClickOverUI() {
        PointerEventData data = new PointerEventData(EventSystem.current) {
            position = Input.mousePosition
        };
        List<RaycastResult> results = new List<RaycastResult>();
        raycaster.Raycast(data, results);
        return results.Count > 0;
    }

}
