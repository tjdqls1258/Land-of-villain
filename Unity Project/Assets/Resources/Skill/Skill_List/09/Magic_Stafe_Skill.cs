using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic_Stafe_Skill : MonoBehaviour, Skill
{
    public GameObject Skill;
    //액티브 스킬
    public void Skill_Action()
    {
        GameObject Player = GameObject.Find("Player");

        float angle = Mathf.Atan2(Joystick.inputDirection.y
            , Joystick.inputDirection.x) * Mathf.Rad2Deg; //플레이어가 바라보는 각도 

        GameObject Skill01 = Instantiate(Skill, Player.transform.position, Quaternion.AngleAxis(angle - 90, Vector3.forward));
        Skill01.GetComponent<Bullte_Setting>().Setting(Player.GetComponent<Player_Stat>().Get_P_State(2));
        gameObject.transform.position = Player.transform.position;

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
