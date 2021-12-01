using UnityEngine;

/// <summary>
/// Class to manage the state of the Plant Model
/// </summary>
public class PlantModelState : MonoBehaviour
{
    [field: SerializeField] public GameObject Arrow { get; set; }
    [field: SerializeField] public GameObject EntryInitial { get; set; }
    [field: SerializeField] public GameObject EntryComplete { get; set; }
    [field: SerializeField] public GameObject EntryRoof { get; set; }
    [field: SerializeField] public GameObject EntryDoor { get; set; }

    GameStateController GameStateScript;
    DebugController DebugLog;

    public bool EntryRoofState { get; private set; }
    public bool ChillerRoofState { get; private set; }
    public bool BoilerRoofState { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        GameStateScript = GameObject.Find("GameStateController").GetComponent<GameStateController>();
        DebugLog = GameObject.Find("DebugController").GetComponent<DebugController>();

        EntryRoofState = true;
        ChillerRoofState = true;
        BoilerRoofState = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameStateScript.EntryRoofTriggered)
        {
            // If user gets first achievement,
            if (GameStateScript.GameStateOne)
            {
                SetEntryRoofAchievementState();
            }
        }
        else
        {
            SetEntryRoofTriggeredState();
        }
    }

    void SetEntryRoofAchievementState()
    {
        // Hide 0/1 text over roof
        EntryInitial.SetActive(false);
        // Display 1/1 text over roof
        EntryComplete.SetActive(true);
        // Display arrow pointing to roof
        Arrow.SetActive(true);
        // Set EntryRoofState to false to so user can remove roof
        EntryRoofState = false;
    }

    void SetEntryRoofTriggeredState()
    {
        EntryRoof.SetActive(false);
        EntryDoor.SetActive(false);
        Arrow.SetActive(false);
        EntryInitial.SetActive(false);
        EntryComplete.SetActive(false);
    }
}
