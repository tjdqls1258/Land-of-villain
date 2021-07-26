using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destory_Self : MonoBehaviour
{
    public float life_time;
    void Update()
    {
        Destroy(gameObject, life_time);
    }
}
