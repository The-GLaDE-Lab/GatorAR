using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementController : MonoBehaviour
{
    [SerializeField]
    GameStateController GameStateController;

    [SerializeField]
    GameObject AchievementCanvas;

    bool AchievementShown;
    // Start is called before the first frame update
    void Start()
    {
        AchievementShown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!AchievementShown)
        {
            if (GameStateController.GameStateOne)
            {
                AchievementCanvas.SetActive(true);
                AchievementShown = true;
            }
        }
    }
}
