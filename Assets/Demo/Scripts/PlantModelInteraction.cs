using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlantModelInteraction : MonoBehaviour
{
    public GameObject objectToPlace, canvasToPlace;

    private GameObject boilerObject, checklistObject, uiObject;
    private Text debugLog;
    private Vector3 cameraForward, cameraBearing, hitPosition;
    private Quaternion currentRotation;

    // Start is called before the first frame update
    void Start()
    {
        debugLog = GameObject.Find("DebugText").GetComponent<Text>();
        checklistObject = GameObject.Find("ChecklistParent").transform.GetChild(0).gameObject;
        uiObject = GameObject.Find("UIParent").transform.GetChild(0).gameObject;
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
                string name = raycastHit.transform.name;

                debugLog.text = "\n" + name;

                GetCameraView();

                hitPosition = raycastHit.transform.position;

                if (raycastHit.collider.CompareTag("Boiler"))
                {
                    debugLog.text += "\nInside Boiler Tag Hit";

                    if (boilerObject == null)
                    {
                        debugLog.text += "\nInside BoilerObject == Null";

                        hitPosition.y += .5f;

                        boilerObject = Instantiate(objectToPlace, hitPosition, currentRotation);
                        boilerObject.AddComponent<ARAnchor>();
                    }
                }
                else if (raycastHit.collider.CompareTag("Start Text"))
                {
                    uiObject.SetActive(false);
                    checklistObject.SetActive(true);

                    Destroy(raycastHit.transform.gameObject);

                    //if (roofObject == null)
                    //{
                    //    debugLog.text += "\nInside RoofObject == Null";

                    //    hitPosition.y += 0.5f;
                    //    hitPosition.z += 0.25f;

                    //    roofObject = Instantiate(canvasToPlace, hitPosition, currentRotation);
                    //    roofObject.AddComponent<ARAnchor>();

                    //    Destroy(raycastHit.transform.gameObject);
                    //}
                }
            }
        }
    }

    void GetCameraView()
    {
        cameraForward = Camera.current.transform.forward;
        cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
        currentRotation = Quaternion.LookRotation(cameraBearing);
    }
}
