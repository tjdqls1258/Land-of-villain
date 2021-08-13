using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Stat : MonoBehaviour
{
    public int N_Stages;

    public int Save_Stages = 0;
    private string Hight_Stages;
    Player_Item items;

    /*
   int MaxHP=100; //최대 체력[0]
   int HP=100; //체력[1]
   int ATK=10; //공격력[2]
   int DEF=5; //방어력[3]
   int AGI=5; //민첩성(이동속도를 담당(추후에 가능하면 공격속도도?))[4]
   int LUC=0; //운(치명타)[5]
   int Money=0 //돈[6]
   */
    //위에 것같은 스탯을 배열로 다룸
    [SerializeField]
    private int[] P_Base_State = new int[] { 100, 100, 10, 5, 5, 0, 0 };
    //이거 
    [SerializeField]
    private int[] P_State = new int[] { 100, 100, 10, 5, 5, 0, 0 };
    
    private void Awake()
    {
        Save_Stages = PlayerPrefs.GetInt(Hight_Stages, 0);
        N_Stages = 1;
        items = this.GetComponent<Player_Item>();
    }
   
    public void Set_P_State(int N1,int N2)
    { P_State[N1] = N2; }
    public void Add_P_State(int N1, int N2)
    { P_State[N1] += N2; }
    public void Miner_P_State(int N1, int N2)
    { P_State[N1] -= N2; }
    public int Get_P_State(int N1)
    {
        return P_State[N1];
    }
    public int Get_P_Base_State(int N1)
    {
        return P_Base_State[N1];
    }
    public void Return_Hight_Score()
    {
        if(N_Stages > Save_Stages)
        {
            Save_Stages = N_Stages;
            PlayerPrefs.SetInt(Hight_Stages, N_Stages);
        }
    }
}
