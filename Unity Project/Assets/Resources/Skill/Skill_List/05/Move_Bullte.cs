using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Bullte : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rigid;
    public float Move_speed;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigid.AddForce(transform.up * Move_speed, ForceMode2D.Force);
    }
}
