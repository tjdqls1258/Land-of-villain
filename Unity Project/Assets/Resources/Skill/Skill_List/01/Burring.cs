﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burring : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }
}
