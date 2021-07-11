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

        player_item[0] = Weapon.GetComponent<Item_stats>().Item_Name;
        player_item[1] = Armor.GetComponent<Item_stats>().Item_Name;
        player_item[2] = Hat.GetComponent<Item_stats>().Item_Name;
        player_item[3] = Ring.GetComponent<Item_stats>().Item_Name;

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

    public bool 아이템_강화(int items, string item_name)
    {
        if(player_item[items] == item_name)
        {
            switch (items)
            {
                case 0:
                    Weapon.GetComponent<Item_stats>().reinforce();
                    Debug.Log("무기강화");
                    if((Weapon.GetComponent<Item_stats>().Item_stat[0] > 10) &&(Weapon.GetComponent<Item_stats>().tear < 2))
                    {
                        string Next_item = "";
                        if(Weapon.GetComponent<Item_stats>().tear == 0)
                        {
                            Next_item = item.get_R_Item(items);
                        }
                        if (Weapon.GetComponent<Item_stats>().tear == 1)
                        {
                            Next_item = item.get_E_Item(items);
                        }
                        Weapon =(GameObject)Resources.Load("Item/Item_Prefab/"+ Next_item);
                        Weapon.GetComponent<Item_stats>().Skill_Set();
                    }
                    
                    return true;
                case 1:
                    Armor.GetComponent<Item_stats>().reinforce();
                    Debug.Log("아머강화");
                    if ((Armor.GetComponent<Item_stats>().Item_stat[0] > 10) &&((Armor.GetComponent<Item_stats>().tear < 2)))
                    {
                        string Next_item = "";
                        if (Armor.GetComponent<Item_stats>().tear == 0)
                        {
                            Next_item = item.get_R_Item(items);
                        }
                        if (Armor.GetComponent<Item_stats>().tear == 1)
                        {
                            Next_item = item.get_E_Item(items);
                        }
                        Armor = (GameObject)Resources.Load("Item/Item_Prefab/" + Next_item);
                        Armor.GetComponent<Item_stats>().Skill_Set();
                    }
                    return true;
                case 2:
                    Hat.GetComponent<Item_stats>().reinforce();
                    Debug.Log("모자강화");
                    if ((Hat.GetComponent<Item_stats>().Item_stat[0] > 10) && ((Hat.GetComponent<Item_stats>().tear < 2)))
                    {
                        string Next_item = "";
                        if (Hat.GetComponent<Item_stats>().tear == 0)
                        {
                            Next_item = item.get_R_Item(items);
                        }
                        if (Hat.GetComponent<Item_stats>().tear == 1)
                        {
                            Next_item = item.get_E_Item(items);
                        }
                        Hat = (GameObject)Resources.Load("Item/Item_Prefab/" + Next_item);
                        Hat.GetComponent<Item_stats>().Skill_Set();
                    }
                    return true;
                case 3:
                    Ring.GetComponent<Item_stats>().reinforce();
                    Debug.Log("반지강화");
                    if ((Ring.GetComponent<Item_stats>().Item_stat[0] > 10) && ((Ring.GetComponent<Item_stats>().tear < 2)))
                    {
                        string Next_item = "";
                        if (Ring.GetComponent<Item_stats>().tear == 0)
                        {
                            Next_item = item.get_R_Item(items);
                        }
                        if (Ring.GetComponent<Item_stats>().tear == 1)
                        {
                            Next_item = item.get_E_Item(items);
                        }
                        Ring.GetComponent<Item_stats>().skill.Stop_Passive();
                        Ring = (GameObject)Resources.Load("Item/Item_Prefab/" + Next_item);
                        Ring.GetComponent<Item_stats>().Skill_Set();
                        Ring.GetComponent<Item_stats>().skill.Skill_Action();
                    }
                    return true;
            }
                
        }
        return false;
    }
}
