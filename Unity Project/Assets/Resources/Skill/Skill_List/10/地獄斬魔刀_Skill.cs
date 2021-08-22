using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 地獄斬魔刀_Skill : MonoBehaviour, Skill
{
    GameObject Player;
    public GameObject Skill;
    public float Distance;

    //액티브 스킬
    public void Skill_Action()
    {
        Player = GameObject.Find("Player");

        float angle = Mathf.Atan2(Joystick.inputDirection.y
            , Joystick.inputDirection.x) * Mathf.Rad2Deg; //플레이어가 바라보는 각도 

        GameObject Skill01s = Instantiate(Skill, Player.transform.position, Quaternion.AngleAxis(angle - 90, Vector3.forward));
        Skill01s.transform.localScale = new Vector3(1, Distance);
        Skill01s.GetComponent<Set_Damage>().SetDamage(Player.GetComponent<Player_Stat>().Get_P_State(2));
        Player.transform.position +=  Skill01s.transform.up * Distance;
        
        Invoke("Des", 0.1f);
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
