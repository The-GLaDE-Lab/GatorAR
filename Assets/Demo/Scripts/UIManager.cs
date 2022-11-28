using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Animator dialog;
    public Animator menuButton;
    public Animator settingsPanel;

    public GameObject cloudEnable, cloudDisable, planeEnable, planeDisable, helpButton;

    static bool cloudEnableStatus, cloudDisableStatus, planeEnableStatus, planeDisableStatus;

    public void ToggleDialog()
    {
        if(dialog.GetBool("isHidden"))
        {
            SaveButtonState();
            HideButtons();
            StartCoroutine(delayShow());
        }
        else
        {
            StartCoroutine(delayHide());
            settingsPanel.SetBool("isSettingsHidden", true);
            menuButton.SetBool("isMenuHidden",true);
            dialog.SetBool("isHidden",true);
        }
    }

    public void ToggleSettings()
    {
        if(settingsPanel.GetBool("isSettingsHidden"))
        {
            StartCoroutine(delayShowSettings());
        }
        else
        {
            StartCoroutine(delayHideSettings());
            settingsPanel.SetBool("isSettingsHidden", true);
        }
    }

    public void SaveButtonState()
    {
        cloudEnableStatus = cloudEnable.activeSelf;
        cloudDisableStatus = cloudDisable.activeSelf;
        planeEnableStatus = planeEnable.activeSelf;
        planeDisableStatus = planeDisable.activeSelf;
    }

    void HideButtons()
    {
        cloudEnable.SetActive(false);
        cloudDisable.SetActive(false);
        planeEnable.SetActive(false);
        planeDisable.SetActive(false);
    }

    void RestoreButtons()
    {
        cloudEnable.SetActive(cloudEnableStatus);
        cloudDisable.SetActive(cloudDisableStatus);
        planeEnable.SetActive(planeEnableStatus);
        planeDisable.SetActive(planeDisableStatus);
    }

    IEnumerator delayShow()
    {
        yield return new WaitForSeconds(0.01f);
        menuButton.SetBool("isMenuHidden",false);
        dialog.SetBool("isHidden",false);
    }

    IEnumerator delayHide()
    {
        yield return new WaitForSeconds(0.5f);
        RestoreButtons();
    }

    IEnumerator delayShowSettings()
    {
        yield return new WaitForSeconds(0.01f);
        settingsPanel.SetBool("isSettingsHidden", false);
    }

    IEnumerator delayHideSettings()
    {
        yield return new WaitForSeconds(0.5f);
    }

    public void OpenHelp()
    {
        Application.OpenURL("google.com");
    }

    public void ToggleHelpFunction()
    {
        helpButton.GetComponent<Button>().enabled = !helpButton.GetComponent<Button>().enabled;
        helpButton.GetComponent<Toggle>().enabled = !helpButton.GetComponent<Toggle>().enabled;
    }
}
