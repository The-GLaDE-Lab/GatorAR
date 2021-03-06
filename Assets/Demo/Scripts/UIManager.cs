using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Animator dialog;
    public Animator menuButton;

    public GameObject cloudEnable, cloudDisable, planeEnable, planeDisable;

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
                menuButton.SetBool("isMenuHidden",true);
                dialog.SetBool("isHidden",true);
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
        yield return new WaitForSeconds(0.02f);
        menuButton.SetBool("isMenuHidden",false);
        dialog.SetBool("isHidden",false);
    }

    IEnumerator delayHide()
    {
        yield return new WaitForSeconds(0.5f);
        RestoreButtons();
    }
}
