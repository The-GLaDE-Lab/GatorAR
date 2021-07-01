using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class to manage scene changing behavior
/// </summary>
public class ChangeScene : MonoBehaviour
{
    /// <summary>
    /// Changes the current scene asynchronously
    /// </summary>
    /// <param name="nextScene">The next scene to be loaded</param>
    public void LoadScene(int nextScene)
    {
        SceneManager.LoadSceneAsync(nextScene);
    }
}

