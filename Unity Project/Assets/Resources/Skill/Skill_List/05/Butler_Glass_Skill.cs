using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butler_Glass_Skill : MonoBehaviour, Skill
{
    GameObject Player;
    int Add_Luk;
    public void Skill_Action()
    {
    }


    public void Passive()
    {
        Player = GameObject.Find("Player");
        Add_Luk = (int)(Player.GetComponent<Player_Stat>().Get_P_State(5) * 0.5f);
        Player.GetComponent<Player_Stat>().Set_P_State(5, (int)(Player.GetComponent<Player_Stat>().Get_P_State(4) + Add_Luk));
    }
    //중지시키는 함수
    public void Stop_Passive()
    {
        if (Player)
        {
            Player.GetComponent<Player_Stat>().Set_P_State(5, (int)(Player.GetComponent<Player_Stat>().Get_P_State(4) - Add_Luk));

        }
    }
}
