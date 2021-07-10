using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Item_01 : MonoBehaviour
{   //플레이어가 현재 지닌 아이템
    private string [] player_item =new string [] { "NONE","NONE","NONE","Copper_Ring"};

    public string Get_Player_Item(int N)
    {
        return player_item[N];
    }
    public void Set_Player_Item(int N1,string N2)
    {
        player_item[N1] = N2;
    }
}
