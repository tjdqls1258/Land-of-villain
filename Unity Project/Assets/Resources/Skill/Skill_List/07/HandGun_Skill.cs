using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGun_Skill : MonoBehaviour, Skill
{
    public float Distance;
    float time;
    Vector3 Dis;
    GameObject Player;
    public void Skill_Action()
    {
        Player = GameObject.Find("Player");

        Dis = new Vector3(Joystick.inputDirection.x, Joystick.inputDirection.y, 0);

        //Player.transform.position -= Dis * Distance * Time.deltaTime;
        time = 0;
        Player.GetComponent<Movement2D>().enabled = false;
        InvokeRepeating("BackStap", 0.0f, 0.05f);
       
    }
    void BackStap()
    {
        if(time <= Distance)
        {
            time += Time.deltaTime;
            Player.transform.position -= Dis * time;
        }
        else
        {
            Player.GetComponent<Movement2D>().enabled = true;
        }
    }
    public void Passive()
    {

    }
    //중지시키는 함수
    public void Stop_Passive()
    {
    }
}
