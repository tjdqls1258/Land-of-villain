using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Item : MonoBehaviour
{
    string[] Items;
    Item item;
    GameObject Waapon, Armor, Ring, Hat;
    void Awake()
    {
        item = new Item();
        
        Waapon = (GameObject)Resources.Load("Item/" + item.get_F_Item(0));
        Armor = (GameObject)Resources.Load("Item/" + item.get_F_Item(1));
        Hat = (GameObject)Resources.Load("Item/" + item.get_F_Item(2));
        Ring = (GameObject)Resources.Load("Item/" + item.get_F_Item(3));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
