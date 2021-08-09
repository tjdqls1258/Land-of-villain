using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turring : MonoBehaviour
{
    public float turnning_speed;
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, turnning_speed * Time.deltaTime));
    }
}
