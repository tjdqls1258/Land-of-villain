using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_bullet : MonoBehaviour
{
    private GameObject Player;
    Rigidbody2D rigid;
    public float Move_speed;
    public float Destory_self_this;
    private Vector3 monsterpos;
    float time;
    //private Vector2 movedir;
    // Start is called before the first frame update
    void Awake()
    { 
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.up, Move_speed * Time.deltaTime);
        //Debug.DrawLine(transform.up * 10f, Player.transform.position, Color.black);
        if (!GameManager.isPause)
        {
            time += Time.deltaTime;
            if (time >= Destory_self_this)
            {
                Destroy(gameObject);
            }
        }
    }
}
