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
        Armor = (GameObject)Resources.Load("Item/Copper_Armor");
        Hat = (GameObject)Resources.Load("Item/Copper_Hat");
        Ring = (GameObject)Resources.Load("Item/Copper_Ring");

        Ring.GetComponent<Item_stats>().Skill_Set();
        Weapon.GetComponent<Item_stats>().Skill_Set();
        Armor.GetComponent<Item_stats>().Skill_Set();
        Hat.GetComponent<Item_stats>().Skill_Set();


        Ring.GetComponent<Item_stats>().skill.Skill_Action();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
