using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Stat : MonoBehaviour
{
    //공 방 체력 민첩
    float ATK; 
    float DF;
    float HP;
    float DEX;

    public void Awake()
    {
        ATK = 10;
        DF = 0;
        HP = 100;
        DEX = 5;
    }

    //받아오기
    public float Get_ATK()
    {
        return ATK;
    }
    public float Get_DF()
    {
        return DF;
    }
    public float Get_HP()
    {
        return HP;
    }
    public float Get_DEX()
    {
        return DEX;
    }

    //설정
    public void Set_ATK(float Value)
    {
        this.ATK = Value;
    }
    public void Set_DF(float Value)
    {
        this.DF = Value;
    }
    public void Set_HP(float Value)
    {
        this.HP = Value;
    }
    public void Set_DEX(float Value)
    {
        this.DEX = Value;
    }

}
