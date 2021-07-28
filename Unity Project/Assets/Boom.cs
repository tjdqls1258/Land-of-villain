﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    private int Damage_s = 0;
    private void Awake()
    {
        Damage_s = 50 + GameObject.Find("Player").GetComponent<Player_Stat>().N_Stages;
    }
    public int Damage()
    {
        return Damage_s;
    }

    public void Set_Damage(int dam)
    {
        this.Damage_s = dam;
    }
}
