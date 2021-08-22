using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate_Hammer_Skill : MonoBehaviour, Skill
{
    GameObject Player;
    public GameObject Skill_Bullte;
    //액티브 스킬
    public void Skill_Action()
    {
        Player = GameObject.Find("Player");
        float angle = Mathf.Atan2(Joystick.inputDirection.y
           , Joystick.inputDirection.x) * Mathf.Rad2Deg;
        GameObject skills =  Instantiate(Skill_Bullte, Player.transform.position, Quaternion.AngleAxis(angle - 90, Vector3.forward));
        skills.GetComponent<Set_Damage>().SetDamage(Player.GetComponent<Player_Stat>().Get_P_State(2));
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
