using UnityEngine;

/// <summary>
/// Class to manage the current state of the game
/// </summary>
public class GameStateController : MonoBehaviour
{
    public bool GameStateOne { get; set; }
    public bool GameStateTwo { get; set; }

    public bool EntryRoofTriggered { get; set; }

    DebugController debugLog;

    void Start()
    {
        debugLog = GameObject.Find("DebugController").GetComponent<DebugController>();
        
        // Game state starts as false, becomes true when achievements completed
        GameStateOne = false;
        GameStateTwo = false;

        EntryRoofTriggered = false;
    }

    void Update()
    {
        if (GameStateOne)
        {
            debugLog.NewLineDebugText("Inside Controller - GameStateOne = True");
        }
    }

}
