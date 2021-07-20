using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player_Item : MonoBehaviour
{
    string[] Items;
    Item item;
    public GameObject Weapon, Armor, Ring, Hat;
    private string[] player_item = new string[] { "NONE", "NONE", "NONE", "NONE" };

    public Image skill1;
    public Image skill2;
    public Image skill3;

    public string Get_Player_Item(int N)
    {
        return player_item[N];
    }
    public void Set_Player_Item(int N1, string N2)
    {
        player_item[N1] = N2;
        Set_Item_Skills();
        Change_item_state();
    }
    void Awake()
    {
        item = new Item();

        //Weapon = (GameObject)Resources.Load("Item/" + item.get_F_Item(0));
        //Weapon = (GameObject)Resources.Load("Item/Item_Prefab/Copper_Sword"); //임시로 넣음
        //Armor = (GameObject)Resources.Load("Item/Item_Prefab/Copper_Armor");
        //Hat = (GameObject)Resources.Load("Item/Item_Prefab/Copper_Hat");
        //Ring = (GameObject)Resources.Load("Item/Item_Prefab/Copper_Ring");

        //player_item[0] = Weapon.GetComponent<Item_stats>().Item_Name;
        //player_item[1] = Armor.GetComponent<Item_stats>().Item_Name;
        //player_item[2] = Hat.GetComponent<Item_stats>().Item_Name;
        //player_item[3] = Ring.GetComponent<Item_stats>().Item_Name;

        if (Ring != null)
        {
            Ring.GetComponent<Item_stats>().Skill_Set();
            Ring.GetComponent<Item_stats>().skill.Skill_Action();
            Ring.GetComponent<Item_stats>().Add_Stat();

        }
        if (Weapon != null)
        {
            Weapon.GetComponent<Item_stats>().Skill_Set();
            Weapon.GetComponent<Item_stats>().Add_Stat();
            skill1.sprite = Weapon.GetComponent<SpriteRenderer>().sprite;
        }
        if (Armor != null)
        {
            Armor.GetComponent<Item_stats>().Skill_Set();
            Armor.GetComponent<Item_stats>().Add_Stat();
            skill2.sprite = Armor.GetComponent<SpriteRenderer>().sprite;
        }
        if (Hat != null)
        {
            Hat.GetComponent<Item_stats>().Skill_Set();
            Hat.GetComponent<Item_stats>().Add_Stat();
            skill3.sprite = Hat.GetComponent<SpriteRenderer>().sprite;
        }
    }

    void Set_Item_Skills()
    {
        if (player_item[0] != "NONE")
        {
            Weapon = (GameObject)Resources.Load("Item/Item_Prefab/" + player_item[0]);
        }
        if(player_item[1]!="NONE")
        {
            Armor = (GameObject)Resources.Load("Item/Item_Prefab/" + player_item[1]);
        }
        if (player_item[2] != "NONE")
        {
            Hat = (GameObject)Resources.Load("Item/Item_Prefab/" + player_item[2]);
        }
        if (player_item[3] != "NONE")
        {
            Ring = (GameObject)Resources.Load("Item/Item_Prefab/" + player_item[3]);
        }
        

        if (Ring != null)
        {
            Ring.GetComponent<Item_stats>().skill.Stop_Passive();
            Ring.GetComponent<Item_stats>().Skill_Set();
            Ring.GetComponent<Item_stats>().skill.Skill_Action();
        }
        if (Weapon != null)
        {
            Weapon.GetComponent<Item_stats>().Skill_Set();
            skill1.sprite = Weapon.GetComponent<SpriteRenderer>().sprite;
        }
        if (Armor != null)
        {
            Armor.GetComponent<Item_stats>().Skill_Set();
            skill2.sprite = Armor.GetComponent<SpriteRenderer>().sprite;
        }
        if (Hat != null)
        {
            Hat.GetComponent<Item_stats>().Skill_Set();
            skill3.sprite = Hat.GetComponent<SpriteRenderer>().sprite;
        }
    }
    public void Change_item_state()
    {
        if(Weapon != null)
        {
            Weapon.GetComponent<Item_stats>().Delete_Stat();
            Weapon.GetComponent<Item_stats>().Add_Stat();
        }
        if(Armor != null)
        {
            Armor.GetComponent<Item_stats>().Delete_Stat();
            Armor.GetComponent<Item_stats>().Add_Stat();
        }
       if(Hat != null)
        {
            Hat.GetComponent<Item_stats>().Delete_Stat();
            Hat.GetComponent<Item_stats>().Add_Stat();
        }
        if (Ring != null)
        {
            Ring.GetComponent<Item_stats>().Delete_Stat();
            Ring.GetComponent<Item_stats>().Add_Stat();
        }
    }
    public bool 아이템_강화(int items, string item_name)
    {
        if(player_item[items] == item_name)
        {
            switch (items)
            {
                case 0:
                    Weapon.GetComponent<Item_stats>().Delete_Stat();
                    Weapon.GetComponent<Item_stats>().reinforce();
                    Weapon.GetComponent<Item_stats>().Add_Stat();
                    //무기 승급
                    if ((Weapon.GetComponent<Item_stats>().Item_stat[0] > 10) &&(Weapon.GetComponent<Item_stats>().tear < 2))
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
                        Change_item_state();
                    }
                    
                    return true;
                case 1:
                    Armor.GetComponent<Item_stats>().Delete_Stat();
                    Armor.GetComponent<Item_stats>().reinforce();
                    Armor.GetComponent<Item_stats>().Add_Stat();
                    //아머 승급
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
                        Change_item_state();
                    }
                    return true;
                case 2:
                    Hat.GetComponent<Item_stats>().Delete_Stat();
                    Hat.GetComponent<Item_stats>().reinforce();
                    Hat.GetComponent<Item_stats>().Add_Stat();
                    //모자 승급
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
                        Change_item_state();
                    }
                    return true;
                case 3:
                    Ring.GetComponent<Item_stats>().Delete_Stat();
                    Ring.GetComponent<Item_stats>().reinforce();
                    Ring.GetComponent<Item_stats>().Add_Stat();
                    //반지 승급
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
                        Change_item_state();
                    }
                    return true;
            }
                
        }
        return false;
    }

    private int player_Money = 0;

    public int Get_Player_Money()
    {
        return player_Money;
    }

    public void Set_Player_Money(int N)
    {
        player_Money = N;
    }
}
