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
        Weapon = (GameObject)Resources.Load("Item_Prefab/Copper_Sword"); //임시로 넣음
        Armor = (GameObject)Resources.Load("Item_Prefab/Copper_Armor");
        Hat = (GameObject)Resources.Load("Item_Prefab/Copper_Hat");
        Ring = (GameObject)Resources.Load("Item_Prefab/Copper_Ring");

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

    // Update is called once per frame
    void Update()
    {
        
    }
}
