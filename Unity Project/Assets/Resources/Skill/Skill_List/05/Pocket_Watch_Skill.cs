using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pocket_Watch_Skill : MonoBehaviour, Skill
{
    GameObject Player;
    int Add_Speed;
    public void Skill_Action()
    {
    }


    public void Passive()
    {
        Player = GameObject.Find("Player");
        Add_Speed = (int)(Player.GetComponent<Player_Stat>().Get_P_State(4) * 0.5f);  
        Player.GetComponent<Player_Stat>().Set_P_State(4, (int)(Player.GetComponent<Player_Stat>().Get_P_State(4) + Add_Speed));
    }
    void Slow_Monster()
    {
        //몬스터 이동속도 감소
    }
    //중지시키는 함수
    public void Stop_Passive()
    {
        if (Player != null)
        {
            Player.GetComponent<Player_Stat>().Set_P_State(4, (int)(Player.GetComponent<Player_Stat>().Get_P_State(4) - Add_Speed));

        }
    }
}
