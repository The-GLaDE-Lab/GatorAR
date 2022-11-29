using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingPanel : MonoBehaviour
{
    public Text QuestionPrompt;
    public GameObject SpecificHeat, MassFlowOut, OutputTemp;
    public Sprite CorrectPNG, IncorrectPNG, FormatPNG;

    DebugController debugLog;

    int qDot;
    int SpecificHeatAnswer, MassFlowOutAnswer, OutputTempAnswer;

    // Start is called before the first frame update
    void Start()
    {
        //debugLog = GameObject.Find("DebugController").GetComponent<DebugController>();
        qDot = Random.Range(100, 2001);
        QuestionPrompt.text += qDot.ToString() + " kW.";
        CalculateAnswers();
    }

    // Update is called once per frame
    void Update()
    {
        /*var target = Camera.main.transform.position;
        target.x = -target.x;
        target.z = -target.z;
        target.y = transform.position.y;
        transform.LookAt(target);*/
        /*var cameraForward = Camera.current.transform.forward;
        var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
        transform.rotation = Quaternion.LookRotation(cameraBearing);*/
    }

    /// <summary>
    /// This function does the math.
    /// </summary>
    public void CalculateAnswers()
    {
        SpecificHeatAnswer = qDot + 1;
        MassFlowOutAnswer = qDot + 2;
        OutputTempAnswer = qDot + 3;
    }

    public void CheckAnswers()
    {
        // Checking Specific Heat
        if (int.TryParse(SpecificHeat.GetComponentInChildren<InputField>().text, out int SpecificHeatInput))
        {
            if (SpecificHeatInput == SpecificHeatAnswer)
            {
                Debug.Log("Specific Heat: Correct");
                //debugLog.NewLineDebugText("Specific Heat: Correct");
                SpecificHeat.GetComponentInChildren<Image>().sprite = CorrectPNG;
            }
            else
            {
                Debug.Log("Specific Heat: Incorrect");
                //debugLog.NewLineDebugText("Specific Heat: Incorrect");
                SpecificHeat.GetComponentInChildren<Image>().sprite = IncorrectPNG;
            }
        }
        else
        {
            Debug.Log("Incorrect Format");
            //debugLog.NewLineDebugText("Incorrect Format");
            SpecificHeat.GetComponentInChildren<Image>().sprite = FormatPNG;
        }

        // Checking Mass Flow Rate Out
        if (int.TryParse(MassFlowOut.GetComponentInChildren<InputField>().text, out int MassFlowOutInput))
        {
            if (MassFlowOutInput == MassFlowOutAnswer)
            {
                Debug.Log("Mass Flow Out: Correct");
                //debugLog.NewLineDebugText("Mass Flow Out: Correct");
                MassFlowOut.GetComponentInChildren<Image>().sprite = CorrectPNG;
            }
            else
            {
                Debug.Log("Mass Flow Out: Incorrect");
                //debugLog.NewLineDebugText("Mass Flow Out: Incorrect");
                MassFlowOut.GetComponentInChildren<Image>().sprite = IncorrectPNG;
            }
        }
        else
        {
            Debug.Log("Incorrect Format");
            //debugLog.NewLineDebugText("Incorrect Format");
            MassFlowOut.GetComponentInChildren<Image>().sprite = FormatPNG;
        }

        // Checking Output Temperature
        if (int.TryParse(OutputTemp.GetComponentInChildren<InputField>().text, out int OutputTempInput))
        {
            if (OutputTempInput == OutputTempAnswer)
            {
                Debug.Log("Output Temperature: Correct");
                //debugLog.NewLineDebugText("Output Temperature: Correct");
                OutputTemp.GetComponentInChildren<Image>().sprite = CorrectPNG;
            }
            else
            {
                Debug.Log("Output Temperature: Incorrect");
                //debugLog.NewLineDebugText("Output Temperature: Incorrect");
                OutputTemp.GetComponentInChildren<Image>().sprite = IncorrectPNG;
            }
        }
        else
        {
            Debug.Log("Incorrect Format");
            //debugLog.NewLineDebugText("Incorrect Format");
            OutputTemp.GetComponentInChildren<Image>().sprite = FormatPNG;
        }
    }
}
