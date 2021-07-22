﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H_Skill_01 : MonoBehaviour, Skill
{
    public float 지속시간;
    int reset_stat;
    public GameObject Buffe_Image;
    GameObject Buffe_;
    public void Skill_Action()
    {
        GameObject Player = GameObject.Find("Player");

        GameObject Buffe_Panel = Player.transform.Find("Play_UI").transform.
            Find("BuffPanel").gameObject;
        Buffe_ = Instantiate(Buffe_Image, Vector3.zero, Quaternion.identity);
        Buffe_.transform.parent = Buffe_Panel.transform;

        reset_stat = Player.GetComponent<Player_Stat>().Get_P_State(4);
        Debug.Log("모자 스킬발사 히히");
        Player.GetComponent<Player_Stat>().Set_P_State(4, (int)(Player.GetComponent<Player_Stat>().Get_P_State(4) * 1.5f));
        Invoke("Buffe", 지속시간);
        
    }
    public void Stop_Passive() { }
    void Buffe()
    {
        GameObject Player = GameObject.Find("Player");
        Player.GetComponent<Player_Stat>().Set_P_State(4, reset_stat);

        Destroy(Buffe_);
        Debug.Log("모자 스킬종료 희희");
    }
}
