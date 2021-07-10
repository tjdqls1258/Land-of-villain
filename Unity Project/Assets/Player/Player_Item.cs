﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Item : MonoBehaviour
{
    string[] Items;
    Item item;
    public GameObject Weapon, Armor, Ring, Hat;
    private string[] player_item = new string[] { "NONE", "NONE", "NONE", "Copper_Ring" };

    public string Get_Player_Item(int N)
    {
        return player_item[N];
    }
    public void Set_Player_Item(int N1, string N2)
    {
        player_item[N1] = N2;
        Set_Item_Skills();
    }
    void Awake()
    {
        item = new Item();

        //Weapon = (GameObject)Resources.Load("Item/" + item.get_F_Item(0));
        Weapon = (GameObject)Resources.Load("Item/Item_Prefab/Copper_Sword"); //임시로 넣음
        Armor = (GameObject)Resources.Load("Item/Item_Prefab/Copper_Armor");
        Hat = (GameObject)Resources.Load("Item/Item_Prefab/Copper_Hat");
        Ring = (GameObject)Resources.Load("Item/Item_Prefab/Copper_Ring");

        player_item[0] = Weapon.ToString();
        player_item[1] = Armor.ToString();
        player_item[2] = Hat.ToString();
        player_item[3] = Ring.ToString();

        if (Ring != null)
        {
            Ring.GetComponent<Item_stats>().Skill_Set();
            Ring.GetComponent<Item_stats>().skill.Skill_Action();
        }
        if (Weapon != null)
        {
            Weapon.GetComponent<Item_stats>().Skill_Set();
        }
        if (Armor != null)
        {
            Armor.GetComponent<Item_stats>().Skill_Set();
        }
        if (Hat != null)
        {
            Hat.GetComponent<Item_stats>().Skill_Set();
        }
    }

    void Set_Item_Skills()
    {
        Weapon = (GameObject)Resources.Load("Item/Item_Prefab/" + player_item[0]);
        Armor = (GameObject)Resources.Load("Item/Item_Prefab/" + player_item[1]);
        Hat = (GameObject)Resources.Load("Item/Item_Prefab/" + player_item[2]);
        Ring = (GameObject)Resources.Load("Item/Item_Prefab/" + player_item[3]);

        if (Ring != null)
        {
            Ring.GetComponent<Item_stats>().Skill_Set();
            Ring.GetComponent<Item_stats>().skill.Skill_Action();
        }
        if (Weapon != null)
        {
            Weapon.GetComponent<Item_stats>().Skill_Set();
        }
        if (Armor != null)
        {
            Armor.GetComponent<Item_stats>().Skill_Set();
        }
        if (Hat != null)
        {
            Hat.GetComponent<Item_stats>().Skill_Set();
        }
    }

    public void 아이템_강화(int item, string item_name)
    {
        if(player_item[item] == item_name)
        {
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
