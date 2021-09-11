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
    public Image skill4;

    public string Get_Player_Item(int N)
    {
        return player_item[N];
    }
    public GameObject Get_Drop_Player_Item(int N)
    {
        switch (N)
        {
            case 0:
                return Weapon;
            case 1:
                return Armor;
            case 2:
                return Hat;
            case 3:
                return Ring;
        }
        return null;
    }
    public void Set_Player_Item(int N1, string N2)
    {
        UnPassive();
        player_item[N1] = N2;
        Change_item_state();
        Set_Item_Skills();
    }
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        item = new Item();

        if (Ring != null) { Ring.GetComponent<Item_stats>().Add_Stat(); }
        if (Hat != null) { Hat.GetComponent<Item_stats>().Add_Stat(); }
        if (Armor != null) { Armor.GetComponent<Item_stats>().Add_Stat(); }
        if (Weapon != null) { Weapon.GetComponent<Item_stats>().Add_Stat(); }

        if (Ring != null)
        {
            Ring.GetComponent<Item_stats>().Skill_Set();
            Ring.GetComponent<Item_stats>().skill.Passive();
            skill4.sprite = Ring.GetComponent<SpriteRenderer>().sprite;

        }
        if (Weapon != null)
        {
            Weapon.GetComponent<Item_stats>().Skill_Set();
            Weapon.GetComponent<Item_stats>().skill.Passive();
            skill1.sprite = Weapon.GetComponent<SpriteRenderer>().sprite;
        }
        if (Armor != null)
        {
            Armor.GetComponent<Item_stats>().Skill_Set();
            Armor.GetComponent<Item_stats>().skill.Passive();
            skill2.sprite = Armor.GetComponent<SpriteRenderer>().sprite;
        }
        if (Hat != null)
        {
            Hat.GetComponent<Item_stats>().Skill_Set();
            Hat.GetComponent<Item_stats>().skill.Passive();
            skill3.sprite = Hat.GetComponent<SpriteRenderer>().sprite;
        }
        
        GetComponent<Player_Stat>().Reset_Speed();
    }


    void Set_Item_Skills()
    {

        if (player_item[0] != "NONE")
        {
            Weapon = (GameObject)Resources.Load("Item/Item_Prefab/" + player_item[0]);
            Weapon.GetComponent<Item_stats>().Skill_Set();
            Weapon.GetComponent<Item_stats>().skill.Passive();
            skill1.sprite = Weapon.GetComponent<SpriteRenderer>().sprite;
        }
        if(player_item[1]!="NONE")
        {
            Armor = (GameObject)Resources.Load("Item/Item_Prefab/" + player_item[1]);
            Armor.GetComponent<Item_stats>().Skill_Set();
            Armor.GetComponent<Item_stats>().skill.Passive();
            skill2.sprite = Armor.GetComponent<SpriteRenderer>().sprite;
        }
        if (player_item[2] != "NONE")
        {
            Hat = (GameObject)Resources.Load("Item/Item_Prefab/" + player_item[2]);
            Hat.GetComponent<Item_stats>().Skill_Set();
            Hat.GetComponent<Item_stats>().skill.Passive();
            skill3.sprite = Hat.GetComponent<SpriteRenderer>().sprite;
        }
        if (player_item[3] != "NONE")
        {           
            Ring = (GameObject)Resources.Load("Item/Item_Prefab/" + player_item[3]);
            Ring.GetComponent<Item_stats>().Skill_Set();
            Ring.GetComponent<Item_stats>().skill.Passive();
            skill4.sprite = Ring.GetComponent<SpriteRenderer>().sprite;
        }

        GetComponent<Player_Stat>().Reset_Speed();
    }
    public void UnPassive()
    {
        if (Ring != null)
        {
            if (Ring.GetComponent<Item_stats>().skill != null)
            {
                Ring.GetComponent<Item_stats>().skill.Stop_Passive();
            }
            
        }
        if (Weapon != null)
        {
            if (Weapon.GetComponent<Item_stats>().skill != null)
            {
                Weapon.GetComponent<Item_stats>().skill.Stop_Passive();
            }
            
        }
        if (Armor != null)
        {
            if (Armor.GetComponent<Item_stats>().skill != null)
            {
                Armor.GetComponent<Item_stats>().skill.Stop_Passive();
            }
           
        }
        if (Hat != null)
        {
            if (Hat.GetComponent<Item_stats>().skill != null)
            {
                Hat.GetComponent<Item_stats>().skill.Stop_Passive();
            }         
        }
    }
    public void Change_item_state()
    {
        if (player_item[0] != "NONE")
        {
            Weapon = (GameObject)Resources.Load("Item/Item_Prefab/" + player_item[0]);
        }
        if (player_item[1] != "NONE")
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

        if (Weapon != null)
        {
            Weapon.GetComponent<Item_stats>().Add_Stat();
        }
        if(Armor != null)
        {
            Armor.GetComponent<Item_stats>().Add_Stat();
        }
       if(Hat != null)
        {
            Hat.GetComponent<Item_stats>().Add_Stat();
        }
        if (Ring != null)
        {
            Ring.GetComponent<Item_stats>().Add_Stat();
        }
        GetComponent<Player_Stat>().Reset_Speed();
    }
    public void Delete_State_item()
    {
        if (Weapon != null)
        {
            Weapon.GetComponent<Item_stats>().Delete_Stat();
        }
        if (Armor != null)
        {
            Armor.GetComponent<Item_stats>().Delete_Stat();
        }
        if (Hat != null)
        {
            Hat.GetComponent<Item_stats>().Delete_Stat();
        }
        if (Ring != null)
        {
            Ring.GetComponent<Item_stats>().Delete_Stat();
        }
        GetComponent<Player_Stat>().Reset_Speed();
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

                    return true;
                case 1:
                    Armor.GetComponent<Item_stats>().Delete_Stat();
                    Armor.GetComponent<Item_stats>().reinforce();
                    Armor.GetComponent<Item_stats>().Add_Stat();
                    return true;
                case 2:
                    Hat.GetComponent<Item_stats>().Delete_Stat();
                    Hat.GetComponent<Item_stats>().reinforce();
                    Hat.GetComponent<Item_stats>().Add_Stat();
                    return true;
                case 3:
                    Ring.GetComponent<Item_stats>().Delete_Stat();
                    Ring.GetComponent<Item_stats>().reinforce();
                    Ring.GetComponent<Item_stats>().Add_Stat();
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
