using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 
{   //Normal 아이템 이름.(일반적인 아이템)
    //아이템을 늘리려면 동일한 배열의 수만큼 배열값을 할당해 줘야함. Copper_Sword2는 예시로 넣어둠
    string[,] N_Item = new string[,] { { "Copper_Sword","Copper_Sword2" },{ "Copper_Armor","NONE" },{ "Copper_Hat","NONE" },{ "Copper_Ring" ,"NONE"} };
    public string get_N_Item()
    {
        int N1 = Random.Range(0, 4);//장비의 종류를 결정해줌.
        int N2; //아이템의 총 개수에서 하나를 가져오기 위한 변수. 
        N2 = Random.Range(0, N_Item.GetLength(1));
        return N_Item[N1, N2];
    }

    //Rare 아이템 이름.(좋은 아이템)

    string[,] R_Item = new string[,] { { "Silver_Sword", "NONE" }, { "Silver_Armor", "NONE" }, { "Silver_Hat", "NONE" }, { "Silver_Ring", "NONE" } };
    public string get_R_Item()
    {
        int N1 = Random.Range(0, 4);//장비의 종류를 결정해줌.
        int N2; //아이템의 총 개수에서 하나를 가져오기 위한 변수. 
        N2 = Random.Range(0, R_Item.GetLength(1));
        return N_Item[N1, N2];
    }

    //Epic 아이템 이름.(희귀한 아이템)


    string[,] E_Item = new string[,] { { "Gold_Sword", "NONE" }, { "Gold_Armor", "NONE" }, { "Gold_Hat", "NONE" }, { "Gold_Ring", "NONE" } };
    public string get_E_Item()
    {
        int N1 = Random.Range(0, 4);//장비의 종류를 결정해줌.
        int N2; //아이템의 총 개수에서 하나를 가져오기 위한 변수. 
        N2 = Random.Range(0, R_Item.GetLength(1));
        return E_Item[N1, N2];
    }
}
