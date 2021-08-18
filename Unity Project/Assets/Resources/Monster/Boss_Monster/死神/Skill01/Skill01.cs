using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill01 : MonoBehaviour
{
    public float ATK_Distance;
    public GameObject Melee_ATK;
    public GameObject ATK;
    private void Awake()
    {
        GameObject Player = GameObject.Find("Player");
        float Distance = Vector2.Distance(Player.transform.position, transform.position);

        if(Distance > ATK_Distance)
        {
            //원거리 공격
            GameObject ATKs = Instantiate(ATK, transform.position, Quaternion.identity);
            ATKs.GetComponent<Skill_damage>().Set_Damage(gameObject.GetComponent<Skill_damage>().Damage());
        }
        else
        {
            //근거리 공격
            GameObject Melee_ATKs = Instantiate(Melee_ATK, transform.position, Quaternion.identity);
            Melee_ATKs.GetComponent<Skill_damage>().Set_Damage(gameObject.GetComponent<Skill_damage>().Damage());
        }
    }
}
