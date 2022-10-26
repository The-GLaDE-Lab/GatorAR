using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

/// <summary>
/// Handles interaction with the some Tracked Image Prefabs
/// </summary>
public class ObjectInteraction : MonoBehaviour
{
    DebugController debugLog;
    ARRaycastManager raycastManager;

    // Start is called before the first frame update
    void Start()
    {
        debugLog = GameObject.Find("DebugController").GetComponent<DebugController>();
        raycastManager = GameObject.Find("AR Session Origin").GetComponent<ARRaycastManager>();
    }

    private void Update() {

        //if (Input.GetMouseButtonDown(0) && !IsClickOverUI()) {
        if (Input.GetTouch(0).phase == TouchPhase.Began) {

            Ray rayCast = Camera.current.ScreenPointToRay(Input.GetTouch(0).position);

            // Check if raycast hits object that has collider
            if (Physics.Raycast(rayCast, out var raycastHit))
            {
                // Get name of collider that has been hit
                debugLog.NewLineDebugText(raycastHit.transform.tag + ":\t");
                debugLog.SameLineDebugText(raycastHit.transform.name);

                if (raycastHit.collider.CompareTag("Intro Shape")) {
                    // This disables the object containing the collider; doesn't respawn
                    raycastHit.transform.gameObject.SetActive(false);

                    // While this results in the object being immediately respawned by the image
                    //gameObject.SetActive(false);
                }

            }
        }
    }

}
