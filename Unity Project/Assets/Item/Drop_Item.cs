using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop_Item 
{
    Item item_Name = new Item();

    //랜덤한 아이템의 이름을 반환하는 함수.
    //get_Place: 아이템이 나오는 장소(?) [희귀 몬스터=0, 보스 몬스터=1, 보물방=2] 
    public string drop_Item(int get_Place)
    { 
 
        switch (get_Place)
        {   //일단은 아무것도 주지 않는 것은 구현안함 만들고 좀 생각해봐야 할 듯
            case 0:
                return Get_Rare_Monster();
            case 1:
                return Get_Boss_Monster();
            case 2:
                return Get_TreasureRoom_Monster();
            default:
                return "NONE";
        }

    }
    public string Get_Rare_Monster()
    {
        int N1 = Random.Range(0, 10);//일반 아이템을 줄지 좋은 아이템을 줄지 결정하는 코드 7(Nomal):3(Rare)
        if (N1 >= 6)
        {return item_Name.get_N_Item();}
        else if (N1 <= 7)
        { return item_Name.get_R_Item(); }
        else
        {return "NONE";}
    }

    public string Get_Boss_Monster()
    {
        int N1 = Random.Range(0, 10);//좋은 아이템을 줄지 희귀한 아이템을 줄지 결정하는 코드 7(Rare) : 3(Epic) 
        if (N1 >= 6)
        { return item_Name.get_R_Item(); }
        else if (N1 <= 7)
        { return item_Name.get_E_Item(); }
        else { return "NONE"; }
    }

    public string Get_TreasureRoom_Monster()
    {
        int N1 = Random.Range(0, 10);//일반,좋은,희귀한 아이템을 줄지 결정하는 코드 2(Namal):4(Rare):4(Epic)
        if (N1 >= 0 && N1 <= 2)
        { return item_Name.get_N_Item(); }
        else if (N1 >= 3 && N1 <= 6)
        { return item_Name.get_R_Item(); }
        else if (N1 >= 7 && N1 <= 9)
        { return item_Name.get_E_Item(); }
        else { return "NONE"; }
    }
}


