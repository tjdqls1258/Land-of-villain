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
            //stats.Set_HP(stats.Get_HP() - 1.0f);
            //hp_bar.Damage(1.0f);
        }
    }
}
