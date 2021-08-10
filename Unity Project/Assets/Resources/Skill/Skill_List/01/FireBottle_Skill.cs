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

        float angle = Mathf.Atan2(Joystick.inputDirection.y
            , Joystick.inputDirection.x) * Mathf.Rad2Deg; //플레이어가 바라보는 각도  

        GameObject SuRuTan1 = Instantiate(FireBottle, Player.transform.position, Quaternion.AngleAxis(angle - 90, Vector3.forward)); ;
        SuRuTan1.GetComponent<Setting_all>().Set_all_Bullte(Player.GetComponent<Player_Stat>().Get_P_State(2));
       

        Debug.Log("수류탄 스킬발사 히히");
    }
}
