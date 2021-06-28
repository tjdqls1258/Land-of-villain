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
        string get_Item_Name="";
 
        switch (get_Place)
        {   //일단은 아무것도 주지 않는 것은 구현안함 만들고 좀 생각해봐야 할 듯
            case 0:
                int N1 = Random.Range(0, 10);//일반 아이템을 줄지 좋은 아이템을 줄지 결정하는 코드 7(Nomal):3(Rare)
                if (N1 >= 6)
                {
                    get_Item_Name= item_Name.get_N_Item();

                }
                else if (N1 <= 7)
                { get_Item_Name= item_Name.get_R_Item(); }
                break;
            case 1:
                int N2 = Random.Range(0, 10);//좋은 아이템을 줄지 희귀한 아이템을 줄지 결정하는 코드 7(Rare) : 3(Epic) 
                if (N2 >= 6)
                { get_Item_Name= item_Name.get_R_Item(); }
                else if (N2 <= 7)
                { get_Item_Name= item_Name.get_E_Item(); }
                break;
            case 2://일반,좋은,희귀한 아이템을 줄지 결정하는 코드 2(Namal):4(Rare):4(Epic)
                int N3 = Random.Range(0, 10);
                if (N3 >= 0 && N3 <= 2)
                { get_Item_Name= item_Name.get_N_Item(); }
                else if (N3 >= 3 && N3 <= 6)
                { get_Item_Name= item_Name.get_R_Item(); }
                else if (N3 >= 7 && N3 <= 9)
                { get_Item_Name= item_Name.get_E_Item(); }
                break;


        }

        return get_Item_Name;
    }
}
