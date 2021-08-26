using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Is_Die_For_Second : MonoBehaviour
{
    public float 생존시간;
    public float delteHp;
    // Start is called before the first frame update
    void Awake()
    {
        delteHp = 1;
        InvokeRepeating("Is_Gone", 0.0f, 1.0f);
    }
    void Is_Gone()
    {
        gameObject.transform.GetComponent<Monster_stats>().Get_damange(1, true);
    }

}
