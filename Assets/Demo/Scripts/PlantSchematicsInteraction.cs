using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PlantSchematicsInteraction : MonoBehaviour
{
    //[SerializeField]
    GameObject uiGameIntro;
    
    //[SerializeField]
    GameObject uiMenu; 

    GameObject robotParent;

    // Start is called before the first frame update
    void Start()
    {
        robotParent = transform.parent.gameObject;

        uiGameIntro = GameObject.Find("SubMenusParent").transform.Find("GameIntroCanvas").gameObject;
        uiMenu = GameObject.Find("UIParent").transform.Find("UICanvas").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            // Perform raycast using position of touch on screen
            Ray rayCast = Camera.current.ScreenPointToRay(Input.GetTouch(0).position);

            // Check if raycast hits object that has collider
            if (Physics.Raycast(rayCast, out var raycastHit))
            {
                if (raycastHit.collider.CompareTag("Schematics"))
                {
                    robotParent.SetActive(false);
                    uiMenu.SetActive(false);
                    uiGameIntro.SetActive(true);
                }
            }
        }
    }
}
