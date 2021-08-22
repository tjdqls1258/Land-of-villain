using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jar_Skill : MonoBehaviour, Skill
{
    //액티브 스킬
    public void Skill_Action()
    {

    }
    //패시브(InvokeRepeating을 사용해서 함수 반복 해야함)
    public void Passive()
    {
        GameObject.Find("Player").GetComponent<Player_Status>().Player_Die();
    }
    //중지시키는 함수
    public void Stop_Passive()
    {
    }
}
