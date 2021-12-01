using UnityEngine;
using UnityEngine.XR.ARFoundation;

/// <summary>
/// Handles interaction with the Power Plant model
/// </summary>
public class PlantModelInteraction : MonoBehaviour
{
    [SerializeField]
    GameObject objectToPlace;

    [SerializeField]
    PlantModelState PlantModelState;

    GameStateController GameStateScript;
    DebugController debugLog;
    GameObject boilerObject;
    Vector3 cameraForward, cameraBearing, hitPosition;
    Quaternion currentRotation;

    // Start is called before the first frame update
    void Start()
    {
        GameStateScript = GameObject.Find("GameStateController").GetComponent<GameStateController>();
        debugLog = GameObject.Find("DebugController").GetComponent<DebugController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if touch occurs and if it is the start of a touch
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            // Perform raycast using position of touch on screen
            Ray rayCast = Camera.current.ScreenPointToRay(Input.GetTouch(0).position);

            // Check if raycast hits object that has collider
            if (Physics.Raycast(rayCast, out var raycastHit))
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
                else if (raycastHit.collider.CompareTag("Entry Roof"))
                {
                    // If Entry Roof is clicked on, check if EntryRoofState is false
                    if (!PlantModelState.EntryRoofState)
                    {
                        GameStateScript.EntryRoofTriggered = true;
                    }
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
