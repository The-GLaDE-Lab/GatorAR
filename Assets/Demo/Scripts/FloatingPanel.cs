using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingPanel : MonoBehaviour
{
    public InputField SpecificHeat;
    public InputField MassFlowOut;
    public InputField OutputTemp;

    DebugController debugLog;

    // Start is called before the first frame update
    void Start()
    {
        debugLog = GameObject.Find("DebugController").GetComponent<DebugController>();
    }

    // Update is called once per frame
    void Update()
    {
        //var target = Camera.main.transform.position;
        //target.x = -target.x;
        //target.z = -target.z;
        //target.y = transform.position.y;
        //transform.LookAt(target);
        var cameraForward = Camera.current.transform.forward;
        var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
        transform.rotation = Quaternion.LookRotation(cameraBearing);
    }

    public void CheckAnswers()
    {
        if (SpecificHeat.text == "1")
        {
            //Debug.Log("Specific Heat:\t\tCorrect");
            debugLog.NewLineDebugText("Specific Heat:\t\tCorrect");
        }
        else
        {
            //Debug.Log("Specific Heat:\t\tIncorrect");
            debugLog.NewLineDebugText("Specific Heat:\tIncorrect");
        }

        if (MassFlowOut.text == "1")
        {
            //Debug.Log("Mass Flow Out:\tCorrect");
            debugLog.NewLineDebugText("Mass Flow Out:\tCorrect");
        }
        else
        {
            //Debug.Log("Mass Flow Out:\tIncorrect");
            debugLog.NewLineDebugText("Mass Flow Out:\tIncorrect");
        }

        if (OutputTemp.text == "1")
        {
            //Debug.Log("Output Temperature:\tCorrect");
            debugLog.NewLineDebugText("Output Temperature:\tCorrect");
        }
        else
        {
            //Debug.Log("Output Temperature:\tIncorrect");
            debugLog.NewLineDebugText("Output Temperature:\tIncorrect");
        }
    }
}
