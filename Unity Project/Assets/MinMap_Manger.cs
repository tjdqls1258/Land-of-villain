using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinMap_Manger : MonoBehaviour
{
    public Camera Main_Cam;
    public Camera Min_Map_Cam;
    public Canvas Player_UI;

    int i = -1;

    public void Switch_Cam()
    {
        if (i == -1)
        {
            Map_On();
            GameManager.isPause = true;
            Time.timeScale = 0.0f;
            i *= -1;
        }
        else
        {
            Map_Off();
            GameManager.isPause = false;
            Time.timeScale = 1.0f;
            i *= -1;
        }
    }
    public void Map_On()
    {
        Min_Map_Cam.enabled = true;
        Player_UI.enabled = false;
        Main_Cam.enabled = false;
    }

    public void Map_Off()
    {
        Main_Cam.enabled = true;
        Player_UI.enabled = true;
        Min_Map_Cam.enabled = false;
    }
}

