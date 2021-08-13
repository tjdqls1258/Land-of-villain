using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set_Damage : MonoBehaviour
{
    int Damage_s;
    public void SetDamage(int Damage_s)
    {
        this.Damage_s = Damage_s;
    }
    public int Damage()
    {
        return Damage_s;
    }
}
