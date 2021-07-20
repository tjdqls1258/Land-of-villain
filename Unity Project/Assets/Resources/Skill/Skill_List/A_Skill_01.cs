using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Skill_01 : MonoBehaviour, Skill
{
    public float 지속시간;
    int reset_stat;
    public void Skill_Action()
    {
        GameObject Player = GameObject.Find("Player");

        reset_stat = Player.GetComponent<Player_Stat>().Get_P_State(3);
        Debug.Log("아머 스킬발사 히히");
        Player.GetComponent<Player_Stat>().Set_P_State(3, (int)(Player.GetComponent<Player_Stat>().Get_P_State(3) * 1.5f));
        Invoke("Buffe", 지속시간);

    }
    public void Stop_Passive() 
    {
    
    }
    void Buffe()
    {
        GameObject Player = GameObject.Find("Player");
        Player.GetComponent<Player_Stat>().Set_P_State(3, reset_stat);
        Debug.Log("아머 스킬종료 희희");
    }
}

