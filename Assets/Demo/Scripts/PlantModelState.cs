using UnityEngine;

/// <summary>
/// Class to manage the state of the Plant Model
/// </summary>
public class PlantModelState : MonoBehaviour
{
    [SerializeField]
    GameObject plantRoof;

    GameStateController gameStateScript;
    DebugController debugLog;
    bool gameStateOne, gameStateTwo;

    // Start is called before the first frame update
    void Start()
    {
        gameStateScript = GameObject.Find("GameStateController").GetComponent<GameStateController>();
        debugLog = GameObject.Find("DebugController").GetComponent<DebugController>();
        // Set initial state of the achievements to false
        gameStateOne = false;
        gameStateTwo = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Every frame, check if the Game State has changed (check if user gets achievement)
        gameStateOne = gameStateScript.GameStateOne;

        // If user gets achievement,
        if (gameStateOne)
        {
            debugLog.NewDebugText("GameStateOne = True");
            debugLog.NewLineDebugText("PlantRoof SetActive = False");
            // Remove the roof of the Plant Model so the user can see inside the next time they view it
            plantRoof.SetActive(false);
        }
    }
}
