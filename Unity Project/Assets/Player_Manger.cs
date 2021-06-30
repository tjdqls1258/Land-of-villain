using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Manger : MonoBehaviour
{
    Player_Stat stats;
    Hp_Bar hp_bar;

    void Start()
    {
        stats = GetComponent<Player_Stat>();
        hp_bar = GetComponent<Hp_Bar>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Monster")
        {
            int Monster_Damage = other.GetComponent<Monster_stats>().damage;
            //stats.Set_P_State(1,stats.Get_P_State(1) - Monster_Damage);
            //hp_bar.Set_Hp(1.0f);
        }
    }
}
