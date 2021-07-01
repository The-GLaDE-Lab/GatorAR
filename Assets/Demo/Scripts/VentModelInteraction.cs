using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handles interaction with the Vent model
/// </summary>
public class VentModelInteraction : MonoBehaviour
{
    DebugController debugLog;
    GameObject achievementPopup;
    GameStateController gameStateScript;

    // Start is called before the first frame update
    void Start()
    {
        debugLog = GameObject.Find("DebugController").GetComponent<DebugController>();
        achievementPopup = GameObject.Find("AchievementPopup").transform.GetChild(0).gameObject;
        gameStateScript = GameObject.Find("GameStateController").GetComponent<GameStateController>();
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

                debugLog.NewDebugText(name);

                // Check if panel on Vent has been hit
                if (raycastHit.collider.CompareTag("Vent"))
                {
                    debugLog.NewLineDebugText("Inside Vent Tag Hit");

                    // Display popup for hitting panel on vent
                    achievementPopup.SetActive(true);

                    // Set Game State One to true, indicating user got achievement
                    gameStateScript.GameStateOne = true;

                    debugLog.NewLineDebugText(gameStateScript.GameStateOne.ToString());
                }
            }
        }
    }
}
