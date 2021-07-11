using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_State_btn : MonoBehaviour
{
    [SerializeField] private GameObject Player_State;

    public void P_State_btn()
    {
        Player_State.SetActive(true);
        Time.timeScale = 0.0f;     
    }

    public void Back_btn()
    {
        Player_State.SetActive(false);
        Time.timeScale = 0.0f;
    }
}
