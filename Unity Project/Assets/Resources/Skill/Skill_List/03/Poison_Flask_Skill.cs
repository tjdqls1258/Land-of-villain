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

        float angle = Mathf.Atan2(Joystick.inputDirection.y
            , Joystick.inputDirection.x) * Mathf.Rad2Deg;

        GameObject FireBottles = Instantiate(FireBottle, Player.transform.position, Quaternion.AngleAxis(angle - 90, Vector3.forward));
        FireBottles.GetComponent<Transform>().localScale = new Vector3(
            FireBottles.GetComponent<Transform>().localScale.x *2,
            FireBottles.GetComponent<Transform>().localScale.y *2,
            1);
        FireBottles.GetComponent<Set_Damage>().SetDamage((int)(Player.GetComponent<Player_Stat>().Get_P_State(2) *2f));


        Debug.Log("수류탄 스킬발사 히히");
    }
}
