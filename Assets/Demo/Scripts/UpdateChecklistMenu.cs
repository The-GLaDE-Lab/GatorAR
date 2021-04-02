using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateChecklistMenu : MonoBehaviour
{
    public Toggle firstTaskToggle, secondTaskToggle,
                  thirdTaskToggle, fourthTaskToggle;

    private GameStateController gameStateScript;
    private bool GameStateOne;

    void Start()
    {
        gameStateScript = GameObject.Find("GameStateController").GetComponent<GameStateController>();
        GameStateOne = false;
    }

    void Update()
    {
        GameStateOne = gameStateScript.GameStateOne;

        if (GameStateOne)
        {
            firstTaskToggle.isOn = true;
        }
    }
}
