using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_Bars : MonoBehaviour
{
    Quaternion quaternion;
    private void Awake()
    {
        quaternion = transform.rotation;
    }

    public void Update()
    {
        transform.rotation = quaternion;
    }
}
