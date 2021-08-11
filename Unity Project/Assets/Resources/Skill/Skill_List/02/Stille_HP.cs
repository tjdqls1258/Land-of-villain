﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stille_HP : MonoBehaviour
{
    GameObject Player;
    int N_HP;
    public int MAX_healing;
    private void Awake()
    {
        Player = GameObject.Find("Player");
        N_HP = Player.GetComponent<Player_Stat>().Get_P_State(1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Monster")
        {
            if (Player.GetComponent<Player_Item>().Ring != null)
            {
                string PlayerRing = Player.GetComponent<Player_Item>().Ring.GetComponent<Item_stats>().Get_Item_Name();
                if (PlayerRing == "Blood_Ring")
                {
                    set_Max_healing(12);
                }
            }
            int Healing = Random.Range(1, MAX_healing);
            if (N_HP + Healing > Player.GetComponent<Player_Stat>().Get_P_State(0))
            {
                Player.GetComponent<Player_Stat>().Set_P_State(
                    1, Player.GetComponent<Player_Stat>().Get_P_State(0));
            }
            else
            {
                Player.GetComponent<Player_Stat>().Set_P_State(1, N_HP + Healing);
            }
        }
    }
    public void set_Max_healing(int healing)
    {
        this.MAX_healing = healing;
    }
}