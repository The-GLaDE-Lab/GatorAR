using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStateController : MonoBehaviour
{
    public bool GameStateOne { get; set; }
    public bool GameStateTwo { get; set; }

    private Text debugLog;

    void Start()
    {
        debugLog = GameObject.Find("DebugText").GetComponent<Text>();
        GameStateOne = false;
        GameStateTwo = false;
    }

    void Update()
    {
        if (GameStateOne)
        {
            debugLog.text += "\n Inside Controller - GameStateOne = True";
        }
    }

}
