using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class to handle update the state of the checklist menu
/// </summary>
public class UpdateChecklistMenu : MonoBehaviour
{
    [SerializeField]
    Toggle firstTaskToggle, secondTaskToggle,
           thirdTaskToggle, fourthTaskToggle;

    GameStateController gameStateScript;
    bool GameStateOne;

    void Start()
    {
        gameStateScript = GameObject.Find("GameStateController").GetComponent<GameStateController>();
        GameStateOne = false;
    }

    void Update()
    {
        // Every frame, check if game state has changed
        GameStateOne = gameStateScript.GameStateOne;

        // Update checkmark on Checklist to be checked
        firstTaskToggle.isOn = GameStateOne;
    }
}
