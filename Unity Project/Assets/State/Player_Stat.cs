using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Stat : MonoBehaviour
{
    public int N_Stages;

    public int Save_Stages = 0;
    private string Hight_Stages;
    Player_Item items;

    public float 이동속도_증가;
    /*
   int MaxHP=100; //최대 체력[0]
   int HP=100; //체력[1]
   int ATK=10; //공격력[2]
   int DEF=5; //방어력[3]
   int AGI=5; //민첩성(이동속도를 담당(추후에 가능하면 공격속도도?))[4]
   int LUC=0; //운(치명타)[5]
   int Money=0 //돈[6]
   [7] 공격속도 - 높을수록 빨라짐 0가 기본 속도
   */
    //위에 것같은 스탯을 배열로 다룸
    [SerializeField]
    private int[] P_Base_State = new int[] { 100, 100, 10, 5, 5, 0, 0, 0, 0 };
    //이거 
    [SerializeField]
    private int[] P_State = new int[] { 100, 100, 10, 5, 5, 0, 0, 0, 0 };

    public int Lenge;
    private void Awake()
    {
        이동속도_증가 = 0;
        Lenge = P_State.Length;
        Save_Stages = PlayerPrefs.GetInt(Hight_Stages, 0);
        N_Stages = 1;
        items = this.GetComponent<Player_Item>();
    }

    public void Set_P_State(int N1, int N2)
    { P_State[N1] = N2; }
    public void Add_P_State(int N1, int N2)
    { P_State[N1] = P_State[N1] + N2; }
    public void Miner_P_State(int N1, int N2)
    { P_State[N1] = P_State[N1] - N2; }
    public int Get_P_State(int N1)
    {
        return P_State[N1];
    }
    public void Set_P_Base_State(int N1, int N2)
    { P_Base_State[N1] = N2; }
    public int Get_P_Base_State(int N1)
    {
        return P_Base_State[N1];
    }
    public void Return_Hight_Score()
    {
        if (N_Stages > Save_Stages)
        {
            Save_Stages = N_Stages;
            PlayerPrefs.SetInt(Hight_Stages, N_Stages);
        }
    }
    public void Reset_Speed()

    {
        GameObject Player = GameObject.Find("Player");
        if (!Player.GetComponent<SkillCooldown>().Don_Restart)
        {
            float add = Mathf.FloorToInt(Player.GetComponent<Player_Stat>().Get_P_State(4) / 20) * 0.1f + 이동속도_증가;

            Player.GetComponent<Movement2D>().moveSpeed = 1.0f + add;
            if(Player.GetComponent<SkillCooldown>().atkdelay)
            {
                Player.GetComponent<Movement2D>().moveSpeed = 1.0f + add - 0.1f;
            }
            if (Player.GetComponent<Movement2D>().moveSpeed >= 1.5f)
            {
                Player.GetComponent<Movement2D>().moveSpeed = 1.5f;
            }
        }
    }
}
