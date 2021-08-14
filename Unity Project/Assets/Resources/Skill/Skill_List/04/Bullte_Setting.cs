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
            if (!(child.GetComponent<Set_Damage>() == null))
            {
                child.GetComponent<Set_Damage>().SetDamage(damage);
            }
        }
    }
}
