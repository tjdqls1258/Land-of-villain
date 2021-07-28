using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_Skill_02 : MonoBehaviour, Skill
{
    GameObject Player;

    private float P_HP;
    private float P_MaxHP;
    private bool isskill = false;

    public float 스킬지속시간;
    public float 스킬쿨타임;
   
    public void Skill_Action()
    {
        Player = GameObject.Find("Player");
        P_MaxHP = Player.GetComponent<Player_Stat>().Get_P_Base_State(0);
        InvokeRepeating("Checktrigger", 0, 0.01f);
    }

    public void Stop_Passive()
    {
        Player.GetComponent<BoxCollider2D>().enabled = true;
    }
    public void Checktrigger()
    {
        P_HP = Player.GetComponent<Player_Stat>().Get_P_State(1);
        if ((P_HP <= (P_MaxHP * 0.2)) && (isskill == false) 
            && (Player.GetComponent<Player_Status>().isinvincible_Check())) 
            //player의 체력이 20% 미만이고 스킬이 쿨타임이 아니며, 현재 데미지를 입었다면
        {
            Invoke("Undying", 0.01f);
        }
    }

    public void Undying()
    {
        isskill = true;
        Player.GetComponent<BoxCollider2D>().enabled = false;
        Player.GetComponent<Player_Stat>().Set_P_State(1, (int)(P_MaxHP * 0.5));
        Invoke("Skill_on", 스킬지속시간);
    }  

    public void Skill_on()
    {
        Player.GetComponent<BoxCollider2D>().enabled = true;
        Invoke("Cooltime", 스킬쿨타임);
    }

    public void Cooltime()
    {
        isskill = false;
    }
}
