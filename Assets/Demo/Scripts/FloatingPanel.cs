using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingPanel : MonoBehaviour
{
    public Text QuestionPrompt;
    public GameObject SpecificHeat, MassFlowOut, OutputTemp;
    public Sprite CorrectPNG, IncorrectPNG, FormatPNG;

    [SerializeField]
    GameStateController GameStateController;

    DebugController debugLog;

    GameObject DiagramPanel, InputOne, InputTwo;
    Text HeatOut, OutputOne, OutputTwo, SpecificHeatText;

    int TolerancePercent = 1;

    int qDot;

    // Variables to store generated answers
    float SpecificHeatAnswer, MassFlowOutAnswer, OutputTempAnswer;

    // Bools to keep track of question progress
    bool SpecificHeatCorrect = false;
    bool MassFlowOutCorrect = false;
    bool OutputTempCorrect = false;

    int InputTemp, MassFlowIn;

    int[] PossibleInputTemps = {-40, -35, -30, -25, -20, -15, -10, -0, 5, 10, 15, 20, 25, 30,
                                35, 40, 45, 50, 55, 60, 65, 70, 75, 80, 85, 90, 95, 100 };

    float[] PossibleSpecificHeats = {0.7486f, 0.7641f, 0.7802f, 0.7972f, 0.8149f, 0.8335f, 0.8531f,
                                    0.8738f, 0.8956f, 0.9187f, 0.9432f, 0.9694f, 0.9976f, 1.028f,
                                    1.061f, 1.098f, 1.138f, 1.184f, 1.237f, 1.298f, 1.372f, 1.462f,
                                    1.577f, 1.731f, 1.948f, 2.281f, 2.865f, 4.144f, 8.785f };

    // Start is called before the first frame update
    void Start()
    {
        GameStateController = GameObject.Find("GameStateController").GetComponent<GameStateController>();
        debugLog = GameObject.Find("DebugController").GetComponent<DebugController>();

        DiagramPanel = GameObject.Find("DiagramPanel");
        HeatOut = DiagramPanel.transform.Find("HeatOut").GetComponent<Text>();
        SpecificHeatText = DiagramPanel.transform.Find("SpecificHeat").GetComponent<Text>();
        OutputOne = DiagramPanel.transform.Find("OutputOne").GetComponent<Text>();
        OutputTwo = DiagramPanel.transform.Find("OutputTwo").GetComponent<Text>();

        InputOne = GameObject.Find("InputOne");
        InputTwo = GameObject.Find("InputTwo");

        CalculateAnswers();
    }

    // Update is called once per frame
    void Update()
    {
        var cameraForward = Camera.current.transform.forward;
        var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
        transform.rotation = Quaternion.LookRotation(cameraBearing);
    }

    /// <summary>
    /// This function does the math.
    /// </summary>
    public void CalculateAnswers()
    {
        int AnswerIndex = Random.Range(6, 28);

        InputTemp = PossibleInputTemps[AnswerIndex];
        MassFlowIn = Random.Range(2, 11);

        SpecificHeatAnswer = PossibleSpecificHeats[AnswerIndex];
        MassFlowOutAnswer = MassFlowIn;
        OutputTempAnswer = InputTemp - Random.Range(20, 60);

        qDot = -(int)(MassFlowIn * SpecificHeatAnswer * (float)(OutputTempAnswer - InputTemp));
        QuestionPrompt.text += qDot.ToString() + " kW.";
        HeatOut.text += qDot.ToString() + " kW";

        InputOne.GetComponentInChildren<Image>().gameObject.SetActive(false);
        InputOne.GetComponentInChildren<Text>().text += InputTemp.ToString() + " \u00B0C";

        InputTwo.GetComponentInChildren<Image>().gameObject.SetActive(false);
        InputTwo.GetComponentInChildren<Text>().text += MassFlowIn.ToString() + " kg/s";

        debugLog.NewLineDebugText("Specific Heat = " + SpecificHeatAnswer.ToString());
        debugLog.NewLineDebugText("Mass Flow Out = " + MassFlowOutAnswer.ToString());
        debugLog.NewLineDebugText("Output Temp = " + OutputTempAnswer.ToString());
        Debug.Log("Specific Heat = " + SpecificHeatAnswer.ToString());
        Debug.Log("Mass Flow Out = " + MassFlowOutAnswer.ToString());
        Debug.Log("Output Temp = " + OutputTempAnswer.ToString());
    }

    bool CheckTolerance(float Input, float Answer, int Percent)
    {
        float UpperBound = Answer * ((float)Percent / 100 + 1);
        float LowerBound = Answer * ((100 - (float)Percent) / 100);

        //Debug.Log("Upper Bound = " + UpperBound.ToString());
        //Debug.Log("Lower Bound = " + LowerBound.ToString());

        if (Answer >= 0)
        {
            if (Input > LowerBound && Input < UpperBound)
                return true;
        }
        else
        {
            if (Input < LowerBound && Input > UpperBound)
                return true;
        }
        return false;
    }

    public void CheckAnswers()
    {
        // Checking Specific Heat
        if (float.TryParse(SpecificHeat.GetComponentInChildren<InputField>().text, out float SpecificHeatInput))
        {
            if (CheckTolerance(SpecificHeatInput, SpecificHeatAnswer, TolerancePercent))
            //if (SpecificHeatInput == SpecificHeatAnswer)
            {
                //Debug.Log("Specific Heat: Correct");
                //debugLog.NewLineDebugText("Specific Heat: Correct");
                SpecificHeat.GetComponentInChildren<Image>().sprite = CorrectPNG;
                SpecificHeat.GetComponentInChildren<InputField>().interactable = false;
                SpecificHeatText.text = "Cp = " + SpecificHeatAnswer.ToString() + " kJ/kg\u2022K";
                SpecificHeatCorrect = true;
            }
            else
            {
                //Debug.Log("Specific Heat: Incorrect");
                //debugLog.NewLineDebugText("Specific Heat: Incorrect");
                SpecificHeat.GetComponentInChildren<Image>().sprite = IncorrectPNG;
            }
        }
        else
        {
            //Debug.Log("Incorrect Format");
            //debugLog.NewLineDebugText("Incorrect Format");
            SpecificHeat.GetComponentInChildren<Image>().sprite = FormatPNG;
        }

        // Checking Mass Flow Rate Out
        if (float.TryParse(MassFlowOut.GetComponentInChildren<InputField>().text, out float MassFlowOutInput))
        {
            if (CheckTolerance(MassFlowOutInput, MassFlowOutAnswer, TolerancePercent))
            //if (MassFlowOutInput == MassFlowOutAnswer)
            {
                //Debug.Log("Mass Flow Out: Correct");
                //debugLog.NewLineDebugText("Mass Flow Out: Correct");
                MassFlowOut.GetComponentInChildren<Image>().sprite = CorrectPNG;
                MassFlowOut.GetComponentInChildren<InputField>().interactable = false;
                OutputTwo.text = "m2 = " + MassFlowOutAnswer.ToString() + " kg/s";
                MassFlowOutCorrect = true;
            }
            else
            {
                //Debug.Log("Mass Flow Out: Incorrect");
                //debugLog.NewLineDebugText("Mass Flow Out: Incorrect");
                MassFlowOut.GetComponentInChildren<Image>().sprite = IncorrectPNG;
            }
        }
        else
        {
            //Debug.Log("Incorrect Format");
            //debugLog.NewLineDebugText("Incorrect Format");
            MassFlowOut.GetComponentInChildren<Image>().sprite = FormatPNG;
        }

        // Checking Output Temperature
        if (float.TryParse(OutputTemp.GetComponentInChildren<InputField>().text, out float OutputTempInput))
        {
            if (CheckTolerance(OutputTempInput, OutputTempAnswer, TolerancePercent))
            //if (OutputTempInput == OutputTempAnswer)
            {
                //Debug.Log("Output Temperature: Correct");
                //debugLog.NewLineDebugText("Output Temperature: Correct");
                OutputTemp.GetComponentInChildren<Image>().sprite = CorrectPNG;
                OutputTemp.GetComponentInChildren<InputField>().interactable = false;
                OutputOne.text = "T2 = " + OutputTempAnswer.ToString() + " \u00B0C";
                OutputTempCorrect = true;
            }
            else
            {
                //Debug.Log("Output Temperature: Incorrect");
                //debugLog.NewLineDebugText("Output Temperature: Incorrect");
                OutputTemp.GetComponentInChildren<Image>().sprite = IncorrectPNG;
            }
        }
        else
        {
            //Debug.Log("Incorrect Format");
            //debugLog.NewLineDebugText("Incorrect Format");
            OutputTemp.GetComponentInChildren<Image>().sprite = FormatPNG;
        }

        if (SpecificHeatCorrect && MassFlowOutCorrect && OutputTempCorrect)
        {
            // Update game state
            GameStateController.GameStateTwo = true;
            //Debug.Log("GameStateTwo: " + GameStateController.GameStateTwo.ToString());
            //debugLog.NewLineDebugText("GameStateTwo: " + GameStateController.GameStateTwo.ToString());
        }
    }
}
