using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop_Item : MonoBehaviour
{
    Item_List IL = new Item_List();

    private string Drop_Item_Name = ""; //drop_Item에서 아이템을 생성할 때 사용되는 변수

    //랜덤한 아이템의 이름을 반환하는 함수.
    //get_Place: 아이템이 나오는 장소(?) [희귀 몬스터=0, 보스 몬스터=1, 보물방=2] 
    public void drop_Item(int get_Place,Transform TS)
    { 
        

        if (get_Place == 0)
        { Drop_Item_Name = Get_Rare_Monster(); }
        else if (get_Place == 1)
        { Drop_Item_Name = Get_Boss_Monster(); }
        else if (get_Place == 2)
        { Drop_Item_Name = Get_TreasureRoom_Monster(); }
        else
        { Drop_Item_Name = "NONE"; }
        //아이템이 아무것도 없지 않는 이상 아이템을 떨굼.
        if (Drop_Item_Name !="NONE")
        {
            GameObject Item_Drop = (GameObject)Instantiate(Resources.Load("Item/Item_Prefab/" + Drop_Item_Name), new Vector2(TS.position.x + Random.Range(-0.01f, 0.01f), TS.position.y + Random.Range(-0.01f, 0.01f)), Quaternion.identity);
            Item_Drop.GetComponent<Item_stats>().reinforce_add = 0;
            for (int i = 0; i < Item_Drop.GetComponent<Item_stats>().Item_stat_add.Length; i++)
            {
                Item_Drop.GetComponent<Item_stats>().Item_stat_add[i] = 0;
            }

        }

    }
    public string Get_Rare_Monster()
    {
        int N1 = Random.Range(0, 100);//일반 아이템을 줄지 좋은 아이템을 줄지 결정하는 코드 7(Nomal):3(Rare)
        if (N1 >= 10 && N1 <= 50)//40%
        {return get_N_Item();}
        else if (N1 > 40 && N1 <= 65)
        { return get_R_Item(); } //25%
        else if (N1 >= 95) //5%
        { return get_E_Item(); }
        else
        {return "NONE";}
    }

    public string Get_Boss_Monster()
    {
        int N1 = Random.Range(0, 10);//좋은 아이템을 줄지 희귀한 아이템을 줄지 결정하는 코드 7(Rare) : 3(Epic) 
        if (N1 >= 6)
        { return get_R_Item(); }
        else if (N1 <= 7)
        { return get_E_Item(); }
        else { return "NONE"; }
    }

    public string Get_TreasureRoom_Monster()
    {
        int N1 = Random.Range(0, 10);//일반,좋은,희귀한 아이템을 줄지 결정하는 코드 2(Namal):4(Rare):4(Epic)
        if (N1 >= 0 && N1 <= 2)
        { return get_N_Item(); }
        else if (N1 >= 3 && N1 <= 6)
        { return get_R_Item(); }
        else if (N1 >= 7 && N1 <= 9)
        { return get_E_Item(); }
        else { return "NONE"; }
    }

    public string get_N_Item()
    {
        int N1 = Random.Range(0, 4);//장비의 종류를 결정해줌.
        int N2; //아이템의 총 개수에서 하나를 가져오기 위한 변수. 
        N2 = Random.Range(0, IL.Get_N_Item_List().GetLength(1));
        return IL.Get_N_Item_Name(N1, N2);
    }
    public string get_R_Item()
    {
        int N1 = Random.Range(0, 4);//장비의 종류를 결정해줌.
        int N2; //아이템의 총 개수에서 하나를 가져오기 위한 변수. 
        N2 = Random.Range(0, IL.Get_R_Item_List().GetLength(1));
        return IL.Get_R_Item_Name(N1, N2);
    }
    public string get_E_Item()
    {
        int N1 = Random.Range(0, 4);//장비의 종류를 결정해줌.
        int N2; //아이템의 총 개수에서 하나를 가져오기 위한 변수. 
        N2 = Random.Range(0, IL.Get_E_Item_List().GetLength(1));
        return IL.Get_E_Item_Name(N1, N2);
    }
}


