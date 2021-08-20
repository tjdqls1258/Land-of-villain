using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGun_Skill : MonoBehaviour, Skill
{
    public float Distance;
    public void Skill_Action()
    {
        GameObject Player = GameObject.Find("Player");

        Vector3 Dis = new Vector3(Joystick.inputDirection.x, Joystick.inputDirection.y, 0);

        Player.transform.position -= Dis * Distance * Time.deltaTime;

    }

    public void Passive()
    {

    }
    //중지시키는 함수
    public void Stop_Passive()
    {
    }
}
