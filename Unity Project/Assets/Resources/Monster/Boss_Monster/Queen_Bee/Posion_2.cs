using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Posion_2 : MonoBehaviour
{
    public int Posion_Damage;
    private void Awake()
    {
        Posion_Damage = Mathf.CeilToInt(GetComponent<Skill_damage>().Damage() % 0.5f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Player_Debuff>().Poison_Debuff(Posion_Damage);
        }
    }
}
