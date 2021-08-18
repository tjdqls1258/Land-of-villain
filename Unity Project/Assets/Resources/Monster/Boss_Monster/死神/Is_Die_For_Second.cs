using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Is_Die_For_Second : MonoBehaviour
{
    public float 생존시간;
    // Start is called before the first frame update
    void Awake()
    {
        Invoke("Is_Gone", 생존시간);
    }
    void Is_Gone()
    {
        gameObject.transform.GetComponent<Monster_stats>().die();
    }

}
