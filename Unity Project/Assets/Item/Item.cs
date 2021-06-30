using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 
{   //Normal 아이템 이름.(일반적인 아이템)
<<<<<<< Updated upstream
    string[] N_Weapon_Item = new string[] { "Copper_Sword" };
   

    string[] N_Armor_Item = new string[] { "Copper_Armor" };

    string[] N_Hat_Item = new string[] { "Copper_Hat" };

    string[] N_Accessory_Item = new string[] { "Copper_Ring" };
=======
    //아이템을 늘리려면 동일한 배열의 수만큼 배열값을 할당해 줘야함. Copper_Sword2는 예시로 넣어둠
    string[,] F_Item = new string[,] { { "Copper_Sword", "Copper_Sword2" }, { "Copper_Armor", "Copper_Armor2" }, { "Copper_Hat", "Copper_Hat2" }, { "Copper_Ring", "Copper_Ring2" } };
    public string Get_First_Item(int N1)
    {
        int N2 = Random.Range(0, F_Item.GetLength(1));
        return F_Item[N1, N2];
    }

    string[,] N_Item = new string[,] { { "Copper_Sword", "Copper_Sword2" }, { "Copper_Armor", "NONE" }, { "Copper_Hat", "NONE" }, { "Copper_Ring", "NONE" } };
>>>>>>> Stashed changes
    public string get_N_Item()
    {
        int N1 = Random.Range(0, 4);//장비의 종류를 결정해줌.
        int N2; //아이템의 총 개수에서 하나를 가져오기 위한 변수. 
        string N3="";//아이템을 이름을 지닐 변수
        if (N1 == 0)
        {
            N2 = Random.Range(0, N_Weapon_Item.Length);
            N3= N_Weapon_Item[N2];
        }
        else if (N1 == 1)
        {
            N2 = Random.Range(0, N_Armor_Item.Length);
            N3 = N_Armor_Item[N2];
        }
        else if (N1 == 2)
        {
            N2 = Random.Range(0, N_Hat_Item.Length);
            N3 = N_Hat_Item[N2];
        }
        else if (N1 == 3)
        {
            N2 = Random.Range(0, N_Accessory_Item.Length);
            N3 = N_Accessory_Item[N2];
        }

        return N3;
    }
    //Rare 아이템 이름.(좋은 아이템)

    string[] R_Weapon_Item = new string[] { "Silver_Sword" };

    string[] R_Armor_Item = new string[] { "Silver_Armor" };

    string[] R_Hat_Item = new string[] { "Silver_Hat" };

    string[] R_Accessory_Item = new string[] { "Silver_Ring" };

    public string get_R_Item()
    {
        int N1 = Random.Range(0, 4);//장비의 종류를 결정해줌.
        int N2; //아이템의 총 개수에서 하나를 가져오기 위한 변수. 
        string N3 = "";//아이템을 이름을 지닐 변수
        if (N1 == 0)
        {
            N2 = Random.Range(0, R_Weapon_Item.Length);
            N3 = R_Weapon_Item[N2];
        }
        else if (N1 == 1)
        {
            N2 = Random.Range(0, R_Armor_Item.Length);
            N3 = R_Armor_Item[N2];
        }
        else if (N1 == 2)
        {
            N2 = Random.Range(0, R_Hat_Item.Length);
            N3 = R_Hat_Item[N2];
        }
        else if (N1 == 3)
        {
            N2 = Random.Range(0, R_Accessory_Item.Length);
            N3 = R_Accessory_Item[N2];
        }

        return N3;
    }

    //Epic 아이템 이름.(희귀한 아이템)

    string[] E_Weapon_Item = new string[] { "Gold_Sword" };

    string[] E_Armor_Item = new string[] { "Gold_Armor" };

    string[] E_Hat_Item = new string[] { "Gold_Hat" };

    string[] E_Accessory_Item = new string[] { "Gold_Ring" };
    public string get_E_Item()
    {
        int N1 = Random.Range(0, 4);//장비의 종류를 결정해줌.
        int N2; //아이템의 총 개수에서 하나를 가져오기 위한 변수. 
        string N3 = "";//아이템을 이름을 지닐 변수
        if (N1 == 0)
        {
            N2 = Random.Range(0, E_Weapon_Item.Length);
            N3 = E_Weapon_Item[N2];
        }
        else if (N1 == 1)
        {
            N2 = Random.Range(0, E_Armor_Item.Length);
            N3 = E_Armor_Item[N2];
        }
        else if (N1 == 2)
        {
            N2 = Random.Range(0, E_Hat_Item.Length);
            N3 = E_Hat_Item[N2];
        }
        else if (N1 == 3)
        {
            N2 = Random.Range(0, E_Accessory_Item.Length);
            N3 = E_Accessory_Item[N2];
        }

        return N3;
    }
}
