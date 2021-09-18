using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set_Damage : MonoBehaviour
{
    int Damage_s;
    public float 데미지_비율 = 1f;
    public void SetDamage(int Damage_s)
    {
        this.Damage_s = (int)(Damage_s * 데미지_비율);
        if(this.Damage_s <= 0)
        {
            this.Damage_s = 1;
        }
    }
    public int Damage()
    {
        return Damage_s;
    }
}
