using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_damage : MonoBehaviour
{

    private int Damage_s = 0;
    public int Damage()
    {
        return Damage_s;
    }
    public void Set_Damage(int dam)
    {
        this.Damage_s = dam;
    }
}
