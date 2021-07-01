using UnityEngine;
using UnityEngine.XR.ARFoundation;

/// <summary>
/// Handles interaction with the Power Plant model
/// </summary>
public class PlantModelInteraction : MonoBehaviour
{
    [SerializeField]
    GameObject objectToPlace, canvasToPlace;

    DebugController debugLog;
    GameObject boilerObject, checklistObject, uiObject;
    Vector3 cameraForward, cameraBearing, hitPosition;
    Quaternion currentRotation;

    // Start is called before the first frame update
    void Start()
    {
        debugLog = GameObject.Find("DebugController").GetComponent<DebugController>();
        checklistObject = GameObject.Find("ChecklistParent").transform.GetChild(0).gameObject;
        uiObject = GameObject.Find("UIParent").transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if touch occurs and if it is the start of a touch
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            // Perform raycast using position of touch on screen
            Ray rayCast = Camera.current.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;

            // Check if raycast hits object that has collider
            if (Physics.Raycast(rayCast, out raycastHit))
            {
                // Get name of collider that has been hit
                string name = raycastHit.transform.name;

                debugLog.NewLineDebugText(name);

                GetCurrentRotation();

                // Get position of the raycast hit
                hitPosition = raycastHit.transform.position;

                // Check if Boiler inside the Plant has been hit
                if (raycastHit.collider.CompareTag("Boiler"))
                {
                    debugLog.NewLineDebugText("Inside Boiler Tag Hit");

                    // If Boiler Object doesn't already exist,
                    if (boilerObject == null)
                    {
                        debugLog.NewLineDebugText("Inside BoilerObject == Null");

                        // Add offset to position of raycast hit (Boiler location)
                        hitPosition.y += .5f;

                        // Instantiate Boiler Object using the object, hit position, and rotation
                        boilerObject = Instantiate(objectToPlace, hitPosition, currentRotation);
                        // Add an AR Anchor to the Boiler Object to keep it in place in the AR space
                        boilerObject.AddComponent<ARAnchor>();
                    }
                }
                else if (raycastHit.collider.CompareTag("Start Text"))
                {
                    // If Start Text tapped on the initial view of the Plant Model,
                    // deactivate the Start Text and display the Checklist to show users
                    // he game objectives.
                    uiObject.SetActive(false);
                    checklistObject.SetActive(true);
                    
                    // Destroy the Start Text
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

    /// <summary>
    /// Gets the current rotation using the camera transform and bearing 
    /// </summary>
    void GetCurrentRotation()
    {
        cameraForward = Camera.current.transform.forward;
        cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
        currentRotation = Quaternion.LookRotation(cameraBearing);
    }
}
