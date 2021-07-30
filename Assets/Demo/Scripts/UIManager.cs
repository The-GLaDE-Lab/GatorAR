using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Animator dialog;
    public Animator menuButton;

    public void OpenDialog()
    {
        menuButton.SetBool("isMenuHidden",false);
        dialog.SetBool("isHidden",false);
    }

    public void CloseDialog()
    {
        menuButton.SetBool("isMenuHidden",true);
        dialog.SetBool("isHidden",true);
    }

    public void ToggleDialog()
    {
        if(dialog.GetBool("isHidden"))
            OpenDialog();
        else
            CloseDialog();
    }

}
