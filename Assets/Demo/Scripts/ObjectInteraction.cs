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
                string tag = raycastHit.transform.tag;

                debugLog.NewLineDebugText(tag);

                if (raycastHit.collider.CompareTag("Red Cube")) {
                    GameObject.Find("IntroFive").SetActive(true);
                    GameObject.Find("IntroFour").SetActive(false);
                    
                    //GameObject.Find("AR Session Origin").GetComponent<ARTrackedImageManager>().enabled = false;
                    //gameObject.transform.Rotate(0, 45, 0);
                }

                if (raycastHit.collider.CompareTag("Blue Sphere")) {
                    //GameObject.Find("Game Piece").transform.Rotate(0, 45, 0);
                    gameObject.SetActive(false);
                }

                if (raycastHit.collider.CompareTag("Green Cylinder")) {
                    GameObject.Find("Game Piece").transform.Rotate(0.0f, 45.0f, 0.0f);
                    gameObject.SetActive(false);
                }
            }
        }
    }

}
