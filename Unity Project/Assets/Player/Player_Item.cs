using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Item : MonoBehaviour
{
    string[] Items;
    Item item;
    public GameObject Weapon, Armor, Ring, Hat;
    void Awake()
    {
        item = new Item();

        //Weapon = (GameObject)Resources.Load("Item/" + item.get_F_Item(0));
        Weapon = (GameObject)Resources.Load("Item/Copper_Sword"); //임시로 넣음
        Armor = (GameObject)Resources.Load("Item/" + item.get_F_Item(1));
        Hat = (GameObject)Resources.Load("Item/" + item.get_F_Item(2));
        Ring = (GameObject)Resources.Load("Item/" + item.get_F_Item(3));

        Weapon.GetComponent<Item_stats>().Skill_Set();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
