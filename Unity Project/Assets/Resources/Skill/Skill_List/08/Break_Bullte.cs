using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break_Bullte : MonoBehaviour
{
    public void Update()
    {
        GameObject Player = GameObject.Find("Player");
        transform.position = Player.transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Monster_Bullet")
        {
            Destroy(collision);
            Destroy(gameObject);
        }
    }
}
