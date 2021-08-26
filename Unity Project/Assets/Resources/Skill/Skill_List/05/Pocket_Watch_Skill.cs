using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pocket_Watch_Skill : MonoBehaviour, Skill
{
    GameObject Player;
    float Add_Speed;
    public void Skill_Action()
    {
    }


    public void Passive()
    {
        Player = GameObject.Find("Player");
        Add_Speed = Player.GetComponent<Movement2D>().moveSpeed * 0.2f;
        Player.GetComponent<Player_Stat>().이동속도_증가 = Add_Speed ;
        Player.GetComponent<Player_Stat>().Reset_Speed();
    }
    void Slow_Monster()
    {
        //몬스터 이동속도 감소
    }
    //중지시키는 함수
    public void Stop_Passive()
    {
        if (Player != null)
        {
            Player.GetComponent<Player_Stat>().이동속도_증가 = 0;
            Player.GetComponent<Player_Stat>().Reset_Speed();
        }
    }
}
