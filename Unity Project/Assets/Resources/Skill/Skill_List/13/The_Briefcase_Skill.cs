using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class The_Briefcase_Skill : MonoBehaviour, Skill
{
    public GameObject Skills;
    GameObject Player;

    float Rotate_Speed;
    float angle;

    int Move_Speed;
    int count;
    //액티브 스킬
    public void Skill_Action()
    {
        Rotate_Speed = 0;
        count = 0;

        Player = GameObject.Find("Player");

        float angle = Mathf.Atan2(Joystick.inputDirection.y
            , Joystick.inputDirection.x) * Mathf.Rad2Deg;

        Rotate_Speed = angle + Random.Range(-90, 90);

        InvokeRepeating("Skill", 0.0f, 0.05f);
    }
    void Skill()
    {
        GameObject Skill01 = Instantiate(Skills, Player.transform.position, Quaternion.AngleAxis(Rotate_Speed, Vector3.forward));
        Skill01.GetComponent<Set_Damage>().SetDamage(Player.GetComponent<Player_Stat>().Get_P_State(2));
        Rotate_Speed = angle + Random.Range(-90,90);
        count++;
        if (count == 5)
        {
            CancelInvoke("Skill");
        }
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
