using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VentModelInteraction : MonoBehaviour
{
    private Text debugLog;
    private GameObject achievementPopup;
    private GameStateController gameStateScript;

    // Start is called before the first frame update
    void Start()
    {
        //raycastManager = FindObjectOfType<ARRaycastManager>();
        debugLog = GameObject.Find("DebugText").GetComponent<Text>();
        achievementPopup = GameObject.Find("AchievementPopup").transform.GetChild(0).gameObject;
        gameStateScript = GameObject.Find("GameStateController").GetComponent<GameStateController>();
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

                debugLog.text = name;

                if (raycastHit.collider.CompareTag("Vent"))
                {
                    debugLog.text += "\nInside Vent Tag Hit";

                    achievementPopup.SetActive(true);

                    gameStateScript.GameStateOne = true;

                    debugLog.text += "\n " + gameStateScript.GameStateOne.ToString();
                }
            }
        }
    }
}
