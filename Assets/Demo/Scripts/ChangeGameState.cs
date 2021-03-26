using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGameState : MonoBehaviour
{
    public void ToggleModelRoof()
    {
        GameObject plantRoof = GameObject.Find("PlantRoof");
        
        if (plantRoof)
        {
            if (plantRoof.activeSelf)
            {
                plantRoof.SetActive(false);
            }
            else
            {
                plantRoof.SetActive(true);
            }
        }
    }

}
