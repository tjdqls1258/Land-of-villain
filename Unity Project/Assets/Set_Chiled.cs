using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set_Chiled : MonoBehaviour
{
    // Start is called before the first frame update

    public void Set_all_Bullte(int Damage)
    {
        Transform[] allChildren = GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            if (child.name == transform.name)
                continue;
            child.GetComponent<Monster_Bullet>().Set_Damage(Damage);
            Debug.Log(child.name);
        }
    }
}
