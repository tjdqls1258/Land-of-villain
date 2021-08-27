using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alchemist_Card_Skill : MonoBehaviour, Skill
{
    GameObject Player;

    public float 지속시간;

    private float P_HP;
    private float P_MaxHP;

    private bool Is_Action = false;
    public void Skill_Action()
    {
        GameObject Player = GameObject.Find("Player");

        if (Player.GetComponent<Player_Stat>().Get_P_State(1) + 50 > Player.GetComponent<Player_Stat>().Get_P_State(0))
        {
            Player.GetComponent<Player_Stat>().Set_P_State(1, Player.GetComponent<Player_Stat>().Get_P_State(0));
        }
        else
        {
            Player.GetComponent<Player_Stat>().Set_P_State(1, Player.GetComponent<Player_Stat>().Get_P_State(1) + 50);
        }
        Debug.Log("아머 스킬발사 히히");
        Is_Action = true;

        Invoke("Buffe", 지속시간);

    }
    public void Stop_Passive()
    {

    }
    public void Passive()
    {

    }
    void Buffe()
    {
        GameObject Player = GameObject.Find("Player");

        Debug.Log("아머 스킬종료 희희");
        Is_Action = false;
    }
}
