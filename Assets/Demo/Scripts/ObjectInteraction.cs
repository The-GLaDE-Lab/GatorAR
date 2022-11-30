using UnityEngine;
using UnityEngine.XR.ARFoundation;

/// <summary>
/// Handles interaction with the some Tracked Image Prefabs
/// </summary>
public class ObjectInteraction : MonoBehaviour
{
    //GameObject uiPanel;
    DebugController debugLog;

    // Start is called before the first frame update
    void Start()
    {
        debugLog = GameObject.Find("DebugController").GetComponent<DebugController>();
    }

    private void Update() {

        //if (Input.GetKeyDown(KeyCode.A)) {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {

            Ray rayCast = Camera.current.ScreenPointToRay(Input.GetTouch(0).position);

            // Check if raycast hits object that has collider
            if (Physics.Raycast(rayCast, out var raycastHit))
            {
                if (raycastHit.collider.CompareTag("Intro Shape"))
                {
                    LogTagAndName(raycastHit);
                    raycastHit.transform.gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

                    if (raycastHit.collider.transform.name == "Intro Sphere")
                    {
                        foreach (GameObject gameObj in FindObjectsOfType<GameObject>(true))
                        {
                            if (gameObj.name == "Intro Cube")
                                gameObj.SetActive(true);
                        }
                    }

                    if (raycastHit.collider.transform.name == "Intro Cylinder")
                    {
                        // This disables the object containing the collider; doesn't respawn
                        raycastHit.transform.gameObject.SetActive(false);

                        // While this results in the object being immediately respawned by the image
                        //gameObject.SetActive(false);
                    }
                }
            }
        }
    }

    private void LogTagAndName(RaycastHit raycastHit)
    {
        debugLog.NewLineDebugText(raycastHit.transform.tag + ":\t");
        debugLog.SameLineDebugText(raycastHit.transform.name);
    }

}
