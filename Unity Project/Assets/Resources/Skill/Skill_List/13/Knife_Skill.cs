using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife_Skill : MonoBehaviour, Skill
{
    public GameObject Skills;
    GameObject Player;
    float Rotate_Speed;
    int Move_Speed;
    //액티브 스킬
    public void Skill_Action()
    {
        Rotate_Speed = 0;
        Player = GameObject.Find("Player");
        Move_Speed = Player.GetComponent<Player_Stat>().Get_P_State(4);
        Player.GetComponent<Player_Stat>().Set_P_State(4,0);
        InvokeRepeating("Skill", 0.0f, 0.05f);
    }
    void Skill()
    {
        GameObject Skill01 = Instantiate(Skills, Player.transform.position, Quaternion.AngleAxis(Rotate_Speed, Vector3.forward));
        Skill01.GetComponent<Set_Damage>().SetDamage(Player.GetComponent<Player_Stat>().Get_P_State(2));
        Rotate_Speed += 10;
        if(Rotate_Speed == 730)
        {
            Player.GetComponent<Player_Stat>().Set_P_State(4, Move_Speed);
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
