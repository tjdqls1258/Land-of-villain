﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_01 : MonoBehaviour, Skill 
{

    public void Skill_Action()
    {
        GameObject Player = GameObject.Find("Player");
        Instantiate((GameObject)Resources.Load(("Skill/P_Skill_01"),typeof(GameObject)),
            Player.transform.position + (Vector3.up * 0.5f), Player.transform.rotation);
        Debug.Log("01번 스킬발사 히히");
    }
}
