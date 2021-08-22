using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Black_Cow_Hat_Skill : MonoBehaviour, Skill
{
    GameObject Player;
    bool check;
    //액티브 스킬
    public void Skill_Action()
    {
        
    }

    void Skills()
    {
        if (Player.GetComponent<Player_Status>().isinvincible_Check() && (check == true))
        {
            if (Random.Range(0, 10) < 2)
            {
                if (Player.GetComponent<Player_Stat>().Get_P_State(2) + 10 >= Player.GetComponent<Player_Stat>().Get_P_State(1))
                {
                    Player.GetComponent<Player_Stat>().Set_P_State(2, Player.GetComponent<Player_Stat>().Get_P_State(1));
                }
                else
                {
                    Player.GetComponent<Player_Stat>().Set_P_State(2, Player.GetComponent<Player_Stat>().Get_P_State(2) + 10);
                }
            }
            check = false;
        }
        else if (!Player.GetComponent<Player_Status>().isinvincible_Check() && (check == false))
        {
            check = true;
        }
    }
    //패시브(InvokeRepeating을 사용해서 함수 반복 해야함)
    public void Passive()
    {
        Player = GameObject.Find("Player");
        InvokeRepeating("Skills", 0.0f, 0.1f);
    }
    //중지시키는 함수
    public void Stop_Passive()
    {
        CancelInvoke("Skills");
    }
}
