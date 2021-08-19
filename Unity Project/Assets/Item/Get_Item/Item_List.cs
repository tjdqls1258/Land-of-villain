using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_List
{
    //아이템을 늘리려면 동일한 배열의 수만큼 배열값을 할당해 줘야함. Copper_Sword2는 예시로 넣어둠
    //Normal 아이템 이름.(일반적인 아이템)
    private string[,] N_Item = new string[,] { { "Copper Sword", "Poison Flask", "Boomerang","Fire Stafe" }, { "Copper Armor", "Alchemist Gown", "Pilot Amor","NONE" }, 
        { "Copper Hat", "Poison Flask", "Pilot Gogle","NONE" }, { "Copper Ring", "Alchemist Card","Pilot Toy","NONE" } };
    //Rare 아이템 이름.(좋은 아이템)
    private string[,] R_Item = new string[,] { { "Silver Sword", "Blood Knife","Blood Folk","FireBottle" }, { "Silver Armor", "Blood Rope","Butler Sweeter","NONE" }, 
        { "Silver Hat", "Blood Hood","Butler Glass","NONE" }, { "Silver Ring", "Blood Ring","Pocket Watch","NONE" } };
    //Epic 아이템 이름.(희귀한 아이템)
    private string[,] E_Item = new string[,] { { "Gold Sword", "SuRuTan","Boomerang Up" }, { "Gold Armor", "NONE","NONE" }, 
        { "Gold Hat", "NONE","NONE" }, { "Gold Ring", "NONE","NONE" } };

    //아이템 리스트 자체를 불러옴(ex)아이템의 갯수를 잴 때?)
    public string[,] Get_N_Item_List()
    {
        return N_Item;
    }
    public string[,] Get_R_Item_List()
    {
        return R_Item;
    }
    public string[,] Get_E_Item_List()
    {
        return E_Item;
    }
    //아이템의 이름을 불러옴
    public string Get_N_Item_Name(int N1,int N2)
    {
        return N_Item[N1, N2] ;
    }

    public string Get_R_Item_Name(int N1,int N2)
    {
        return R_Item[N1,N2];
    }

    public string Get_E_Item_Name(int N1,int N2)
    {
        return E_Item[N1,N2];
    }
}
