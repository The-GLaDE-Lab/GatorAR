using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Animator dialog;
    public Animator menuButton;

    public void ToggleDialog()
    {
        if(dialog.GetBool("isHidden"))
            {
                menuButton.SetBool("isMenuHidden",false);
                dialog.SetBool("isHidden",false);
            }
        else
            {
                menuButton.SetBool("isMenuHidden",true);
                dialog.SetBool("isHidden",true);
            }
    }
}
