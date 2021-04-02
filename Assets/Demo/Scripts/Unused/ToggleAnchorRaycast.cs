using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class ToggleAnchorRaycast : MonoBehaviour
{
    public ARSessionOrigin aROrigin;
    public GameObject aRInteraction;

    public void ToggleAnchorRay()
    {
        aROrigin.GetComponent<ReferencePointManager>().enabled = !aROrigin.GetComponent<ReferencePointManager>().enabled;
        aRInteraction.GetComponent<ARTapToPlaceObject>().enabled = !aRInteraction.GetComponent<ARTapToPlaceObject>().enabled;
    }
}