using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBottle_Skill : MonoBehaviour, Skill
{
    public GameObject FireBottle;
    public void Stop_Passive() { }
    public void Skill_Action()
    {
        GameObject Player = GameObject.Find("Player");


        GameObject FireBottles = Instantiate(FireBottle, Player.transform.position, Quaternion.identity);
        FireBottles.GetComponent<Setting_all>().Set_all_Bullte(Player.GetComponent<Player_Stat>().Get_P_State(2));
       

        Debug.Log("수류탄 스킬발사 히히");
    }
}
