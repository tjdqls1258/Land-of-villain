﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Black_Cow_Armor_Skill : MonoBehaviour, Skill
{
    public float 지속시간;
    int reset_stat;
    public GameObject Buffe_Image;
    private bool Is_Action = false;

    GameObject Buffe_;

    public void Skill_Action()
    {
        GameObject Player = GameObject.Find("Player");
        if (Player.GetComponent<Player_Stat>().Get_P_State(6) >= 10)
        {
            GameObject Buffe_Panel = Player.transform.Find("Play_UI").transform.
            Find("BuffPanel").gameObject;
            Buffe_ = Instantiate(Buffe_Image, Vector3.zero, Quaternion.identity);
            Buffe_.transform.parent = Buffe_Panel.transform;
            Is_Action = true;
            reset_stat = (int)(Player.GetComponent<Player_Stat>().Get_P_State(3));

            Player.GetComponent<Player_Stat>().Set_P_State(6, Player.GetComponent<Player_Stat>().Get_P_State(6) - 10);
            Debug.Log("모자 스킬발사 히히");
            Player.GetComponent<Player_Stat>().Set_P_State(3, Player.GetComponent<Player_Stat>().Get_P_State(3) + reset_stat);
            Invoke("Buffe", 지속시간);
        }
    }
    public void Passive()
    {

    }
    public void Stop_Passive()
    {

    }
    void Buffe()
    {
        GameObject Player = GameObject.Find("Player");
        Player.GetComponent<Player_Stat>().Set_P_State(3, Player.GetComponent<Player_Stat>().Get_P_State(3) - reset_stat);
        Is_Action = false;
        Destroy(Buffe_);
        Debug.Log("모자 스킬종료 희희");
    }
}
