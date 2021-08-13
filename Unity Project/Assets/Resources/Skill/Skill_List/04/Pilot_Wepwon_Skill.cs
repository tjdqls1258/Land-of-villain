using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pilot_Wepwon_Skill : MonoBehaviour,Skill
{
    public GameObject FireBottle;
    public void Stop_Passive() { }
    public void Passive() { }
    public void Skill_Action()
    {
        GameObject Player = GameObject.Find("Player");


        GameObject FireBottles = Instantiate(FireBottle, Player.transform.position, Quaternion.identity);
        FireBottles.GetComponent<Bullte_Setting>().Setting(Player.GetComponent<Player_Stat>().Get_P_State(2));


        Debug.Log("수류탄 스킬발사 히히");

    }
}
