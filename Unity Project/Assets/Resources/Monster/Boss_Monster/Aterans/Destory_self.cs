using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destory_self : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Invoke("Destroys",0.7f);
    }
    void Destroys()
    {
        Destroy(gameObject);
    }

}
