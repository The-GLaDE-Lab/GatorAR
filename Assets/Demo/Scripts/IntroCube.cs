using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroCube : MonoBehaviour
{
    GameObject introParent;
    GameObject uiPanelOne, uiPanelTwo;
    DebugController debugLog;
    int tapCount;
    
    // Start is called before the first frame update
    void Start()
    {
        tapCount = 0;
        foreach (GameObject gameObj in FindObjectsOfType<GameObject>(true))
        {
            if (gameObj.name == "IntroParent")
            {
                introParent = gameObj;
            }
        }
        uiPanelOne = introParent.transform.Find("IntroFour").gameObject;
        uiPanelTwo = introParent.transform.Find("IntroFive").gameObject;

        debugLog = GameObject.Find("DebugController").GetComponent<DebugController>();
        debugLog.NewLineDebugText("Intro Parent: " + "\t" + introParent.activeInHierarchy.ToString());
        debugLog.NewLineDebugText("UI One: " + "\t" + uiPanelOne.activeInHierarchy.ToString());
        debugLog.NewLineDebugText("UI Two: " + "\t" + uiPanelTwo.activeInHierarchy.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.A))
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {

            Ray rayCast = Camera.current.ScreenPointToRay(Input.GetTouch(0).position);

            // Check if raycast hits object that has collider
            if (Physics.Raycast(rayCast, out var raycastHit))
            {
                
                if (raycastHit.collider.transform.name == "Intro Cube")
                {
                    raycastHit.transform.gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
                    tapCount++;

                    LogTagAndName(raycastHit);
                    debugLog.SameLineDebugText("taps: " + tapCount + "\t");
                    debugLog.SameLineDebugText(uiPanelOne.activeInHierarchy.ToString());

                    if (tapCount > 5)
                    {
                        raycastHit.transform.gameObject.SetActive(false);
                        tapCount = 0;
                    }

                    if (uiPanelOne.activeInHierarchy)
                    {
                        uiPanelOne.SetActive(false);
                        uiPanelTwo.SetActive(true);
                    }
                }
            }
        }
    }
    private void LogTagAndName(RaycastHit raycastHit)
    {
        debugLog.NewLineDebugText(raycastHit.transform.tag + ":\t");
        debugLog.SameLineDebugText(raycastHit.transform.name + " -\t");
    }
}
