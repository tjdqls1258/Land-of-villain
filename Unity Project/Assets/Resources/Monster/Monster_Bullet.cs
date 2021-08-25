using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Bullet : MonoBehaviour
{
    Rigidbody2D rigid;
    public float Move_speed;

    private int Damage_s = 0;

    float time;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.up, Move_speed * Time.deltaTime); ;
        if (!GameManager.isPause)
        {
            time += Time.deltaTime;
            if (time >= 5)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        
    }

    public int Damage()
    {
        return Damage_s;
    }
    public void Set_Damage(int dam)
    {
        this.Damage_s = dam;
    }
}
