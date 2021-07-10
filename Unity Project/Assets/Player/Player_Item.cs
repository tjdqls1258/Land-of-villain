using System.Collections;
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
    }
    void Awake()
    {
        item = new Item();

        //Weapon = (GameObject)Resources.Load("Item/" + item.get_F_Item(0));
        Weapon = (GameObject)Resources.Load("Item/Copper_Sword"); //임시로 넣음
        Armor = (GameObject)Resources.Load("Item/Copper_Armor");
        Hat = (GameObject)Resources.Load("Item/Copper_Hat");
        Ring = (GameObject)Resources.Load("Item/Copper_Ring");

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
