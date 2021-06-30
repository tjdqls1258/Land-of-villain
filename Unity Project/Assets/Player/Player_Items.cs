using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Items : MonoBehaviour
{
    string[] Player_items = { }; //플레이어가 가지고 있는 아이템 배열
    Item item;
    void Awake()
    {
        item = new Item();
        Player_items[0] = item.Get_First_Item(0);
        Player_items[1] = item.Get_First_Item(1);
        Player_items[2] = item.Get_First_Item(2);
        Player_items[3] = item.Get_First_Item(3);
    }

    void Update()
    {
        
    }
}
