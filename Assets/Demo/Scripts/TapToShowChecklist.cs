using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TapToShowChecklist : MonoBehaviour
{
    [SerializeField]
    private Text debugLog;

    public GameObject objectToPlace;

    //private ARRaycastManager raycastManager;
    private GameObject boilerObject;

    // Start is called before the first frame update
    void Start()
    {
        //raycastManager = FindObjectOfType<ARRaycastManager>();
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

                debugLog.text += "\n" + name;

                if (raycastHit.collider.CompareTag("Boiler"))
                {
                    debugLog.text += "\nInside Tag Hit";

                    if (boilerObject == null)
                    {
                        debugLog.text += "\nInside BoilerObject == Null";
                        Vector3 cameraForward = Camera.current.transform.forward;
                        Vector3 cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;

                        Quaternion boilerRotation = Quaternion.LookRotation(cameraBearing);
                        Vector3 boilerPosition = raycastHit.transform.position;
                        boilerPosition.y += 5;

                        boilerObject = Instantiate(objectToPlace, boilerPosition, boilerRotation);
                        boilerObject.AddComponent<ARAnchor>();
                    }
                }
            }
        }
    }
}
