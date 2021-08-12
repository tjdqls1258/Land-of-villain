using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison_Flask_Skill : MonoBehaviour, Skill
{
    public GameObject FireBottle;
    public void Stop_Passive() { }
    public void Passive() { }
    public void Skill_Action()
    {
        GameObject Player = GameObject.Find("Player");


        GameObject FireBottles = Instantiate(FireBottle, Player.transform.position, Quaternion.identity);
        FireBottles.GetComponent<Transform>().localScale = new Vector3(
            FireBottles.GetComponent<Transform>().localScale.x *2,
            FireBottles.GetComponent<Transform>().localScale.y *2,
            1);
        FireBottles.GetComponent<Player_bullet>().Set_Damage(FireBottle.GetComponent<Player_bullet>().Damage() * 2);


        Debug.Log("수류탄 스킬발사 히히");
    }
}
