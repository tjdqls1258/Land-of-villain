using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Posion_2 : MonoBehaviour
{
    int Posion_Damage;
    private void Awake()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Posion_Damage = Mathf.CeilToInt(GetComponent<Skill_damage>().Damage() * 0.5f);
            collision.GetComponent<Player_Debuff>().Poison_Debuff(Posion_Damage);
        }
    }
}
