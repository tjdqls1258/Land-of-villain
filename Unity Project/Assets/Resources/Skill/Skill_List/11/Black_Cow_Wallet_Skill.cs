using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Black_Cow_Wallet_Skill : MonoBehaviour, Skill
{
    //액티브 스킬
    public void Skill_Action()
    {
        GameObject Player = GameObject.Find("Player");
        if (Player.GetComponent<Player_Stat>().Get_P_State(6) >= 10)
        {
            Player.GetComponent<Player_Stat>().Set_P_State(6, Player.GetComponent<Player_Stat>().Get_P_State(6) -10);
            if(Player.GetComponent<Player_Stat>().Get_P_State(2)+10 >= Player.GetComponent<Player_Stat>().Get_P_State(1))
            {
                Player.GetComponent<Player_Stat>().Set_P_State(2, Player.GetComponent<Player_Stat>().Get_P_State(1));
            }
            else
            {
                Player.GetComponent<Player_Stat>().Set_P_State(2, Player.GetComponent<Player_Stat>().Get_P_State(2) + 10);
            }
        }
    }
    //패시브(InvokeRepeating을 사용해서 함수 반복 해야함)
    public void Passive()
    {

    }
    //중지시키는 함수
    public void Stop_Passive()
    {
    }
}
