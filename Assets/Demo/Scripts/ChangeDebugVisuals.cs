using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ChangeDebugVisuals : MonoBehaviour
{
    ARPointCloudManager aRPointCloudManager;
    ARPlaneManager aRPlaneManager;
    ARSessionOrigin aRSessionOrigin;

    public void DisablePointCloudVisual()
    {
        aRSessionOrigin = FindObjectOfType<ARSessionOrigin>();
        aRPointCloudManager = aRSessionOrigin.GetComponent<ARPointCloudManager>();

        aRPointCloudManager.SetTrackablesActive(false);
        aRPointCloudManager.enabled = false;
    }

    public void EnablePointCloudVisual()
    {
        aRSessionOrigin = FindObjectOfType<ARSessionOrigin>();
        aRPointCloudManager = aRSessionOrigin.GetComponent<ARPointCloudManager>();

        aRPointCloudManager.SetTrackablesActive(true);
        aRPointCloudManager.enabled = true;
    }
    public void DisablePlaneVisual()
    {
        aRSessionOrigin = FindObjectOfType<ARSessionOrigin>();
        aRPlaneManager = aRSessionOrigin.GetComponent<ARPlaneManager>();

        aRPlaneManager.SetTrackablesActive(false);
        aRPlaneManager.enabled = false;
    }

    public void EnablePlaneVisual()
    {
        aRSessionOrigin = FindObjectOfType<ARSessionOrigin>();
        aRPlaneManager = aRSessionOrigin.GetComponent<ARPlaneManager>();

        aRPlaneManager.SetTrackablesActive(true);
        aRPlaneManager.enabled = true;
    }

}
