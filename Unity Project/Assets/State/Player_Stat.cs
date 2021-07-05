using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Stat : MonoBehaviour
{
    /*
    int MaxHP=100; //최대 체력[0]
    int HP=100; //체력[1]
    int ATK=10; //공격력[2]
    int DEF=5; //방어력[3]
    int AGI=5; //민첩성(이동속도를 담당(추후에 가능하면 공격속도도?))[4]
    int LUC=0; //운(치명타)[5]
    int Money=0; //소지금[6]
    */
    //위에 것같은 스탯을 배열로 다룸
    private int[] P_State;
    public int N_Stages;

    private void Awake()
    {
        P_State = new int[] { 100, 100, 10, 5, 5, 0, 0 };
        N_Stages = 1;
    }
    public void Set_P_State(int N1,int N2)
    { P_State[N1] = N2; }
    public int Get_P_State(int N1)
    {
        return P_State[N1];
    }
}
