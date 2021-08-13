using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullte_Setting : MonoBehaviour
{
   public void Setting(int damage)
    {
        Transform[] allChildren = GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            if (child.name == transform.name)
                continue;
            if (!(child.GetComponent<Skill_Danamge>() == null))
            {
                child.GetComponent<Skill_Danamge>().Set_Damage(damage);
            }
        }
    }
}
