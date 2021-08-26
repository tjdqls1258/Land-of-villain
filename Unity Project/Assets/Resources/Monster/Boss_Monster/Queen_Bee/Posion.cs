using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Posion : MonoBehaviour
{
    public int Posion_Damages;
    private void Awake()
    {
        Posion_Damages = Mathf.CeilToInt(GetComponent<Monster_Bullet>().Damage() * 0.1f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Player_Debuff>().Poison_Debuff(Posion_Damages);
        }
    }
}
