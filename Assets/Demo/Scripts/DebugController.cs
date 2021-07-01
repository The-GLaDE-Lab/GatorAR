using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class to handle displaying debug info to the custom debug window in the AR scene
/// </summary>
public class DebugController : MonoBehaviour
{
    [SerializeField]
    Text DebugText;

    /// <summary>
    /// Sets debug text to a new string, clearing old debug info
    /// </summary>
    /// <param name="debugText">New debug text to be displayed</param>
    public void NewDebugText(string debugText)
    {
        DebugText.text = debugText;
    }

    /// <summary>
    /// Adds text to the same debug line that is currently being displayed
    /// </summary>
    /// <param name="debugText">Debug text to displayed on current line</param>
    public void SameLineDebugText(string debugText)
    {
        DebugText.text += debugText;
    }

    /// <summary>
    /// Adds a new line of text to the debug info that is currently being displayed
    /// </summary>
    /// <param name="debugText">Debug text to be displayed on new line</param>
    public void NewLineDebugText(string debugText)
    {
        DebugText.text += "\n" + debugText;
    }
}
