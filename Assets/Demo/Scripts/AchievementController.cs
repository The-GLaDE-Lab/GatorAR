using UnityEngine;

public class AchievementController : MonoBehaviour
{
    [SerializeField]
    GameStateController GameStateController;

    // The UI component to be shown as the achievement
    [SerializeField]
    GameObject AchievementCanvas;

    // Used to keep track of achievement status
    bool AchievementShown;

    // Start is called before the first frame update
    void Start()
    {
        //  Achievement hidden at start
        AchievementShown = false;
    }

    // Update is called once per frame
    void Update()
    {
        /* This ensures the achievement only pops up once as 
         * there is no method to set this bool back to false */
        if (!AchievementShown)
        {
            // Check for updated game state
            if (GameStateController.GameStateOne)
            {
                // Enables achievement popup in UI
                AchievementCanvas.SetActive(true);
                AchievementShown = true;
            }
        }
    }
}
