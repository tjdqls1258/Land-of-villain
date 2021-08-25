using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting_Skill_M : MonoBehaviour
{
    public void Set_all_Bullte(int Damage)
    {
        Transform[] allChildren = GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            if (child.name == transform.name)
                continue;
            child.GetComponent<Skill_damage>().Set_Damage(Damage);
        }
    }
}
