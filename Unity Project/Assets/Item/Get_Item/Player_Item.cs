﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Item : MonoBehaviour
{   //플레이어가 현재 지닌 아이템
    private string [] player_Item =new string [] { "NONE","NONE","NONE","Copper_Ring"};
    //플레이어의 소지금
    
    public string Get_Player_Item(int N)
    {
        return player_Item[N];
    }
    public void Set_Player_Item(int N1,string N2)
    {
        player_Item[N1] = N2;
    }

}
