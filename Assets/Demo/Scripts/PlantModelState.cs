using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantModelState : MonoBehaviour
{
    public GameObject plantRoof;

    private GameStateController gameStateScript;
    private bool GameStateOne, GameStateTwo;
    private Text debugLog;

    // Start is called before the first frame update
    void Start()
    {
        gameStateScript = GameObject.Find("GameStateController").GetComponent<GameStateController>();
        debugLog = GameObject.Find("DebugText").GetComponent<Text>();
        GameStateOne = false;
        GameStateTwo = false;
    }

    // Update is called once per frame
    void Update()
    {
        GameStateOne = gameStateScript.GameStateOne;

        if (GameStateOne)
        {
            debugLog.text = "GameStateOne = True";
            debugLog.text += "\n PlantRoof SetActive = False";
            plantRoof.SetActive(false);
        }
    }
}
