using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TapToShowChecklist : MonoBehaviour
{
    public GameObject objectToPlace;

    private ARRaycastManager raycastManager;
    private GameObject boilerObject;

    // Start is called before the first frame update
    void Start()
    {
        raycastManager = FindObjectOfType<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Ray rayCast = Camera.current.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;

            if (Physics.Raycast(rayCast, out raycastHit))
            {
                if (raycastHit.collider.CompareTag("Boiler"))
                {
                    Transform boilerTransform = raycastHit.transform;

                    if (boilerObject == null)
                    {
                        Vector3 cameraForward = Camera.current.transform.forward;
                        Vector3 cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
                        
                        boilerTransform.rotation = Quaternion.LookRotation(cameraBearing);
                        boilerTransform.position = new Vector3(boilerTransform.position.x, boilerTransform.position.y + 2, boilerTransform.position.z);

                        boilerObject = Instantiate(objectToPlace, boilerTransform.position, boilerTransform.rotation);
                        boilerObject.AddComponent<ARAnchor>();
                    }
                }
            }
        }
    }
}
