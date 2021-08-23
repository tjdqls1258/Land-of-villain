using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butler_Sweeter_Skill : MonoBehaviour, Skill
{
    GameObject Player;
    int Add_ATK;
    int Add_Luk;
    public void Skill_Action()
    {
    }


    public void Passive()
    {
        Player = GameObject.Find("Player");
        Add_Luk = (int)(Player.GetComponent<Player_Stat>().Get_P_State(5) * 0.5f);
        Add_ATK = (int)(Player.GetComponent<Player_Stat>().Get_P_State(2) * 0.2f);



        Player.GetComponent<Player_Stat>().Set_P_State(5, (int)(Player.GetComponent<Player_Stat>().Get_P_State(5) + Add_Luk));
        Player.GetComponent<Player_Stat>().Set_P_State(2, (int)(Player.GetComponent<Player_Stat>().Get_P_State(2) + Add_ATK));
    }
    //중지시키는 함수
    public void Stop_Passive()
    {
        if (Player != null)
        {
            Player.GetComponent<Player_Stat>().Set_P_State(5, (int)(Player.GetComponent<Player_Stat>().Get_P_State(5) - Add_Luk));
            Player.GetComponent<Player_Stat>().Set_P_State(2, (int)(Player.GetComponent<Player_Stat>().Get_P_State(2) - Add_ATK));
        }
    }
}
