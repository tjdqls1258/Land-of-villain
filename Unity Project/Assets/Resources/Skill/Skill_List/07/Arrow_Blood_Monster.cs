using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow_Blood_Monster : MonoBehaviour
{
    //10% 확률 출혈 효과 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Monster")
        {
            int Ran = (Random.Range(0, 10));
            if(Ran == 1)
            {
                other.gameObject.GetComponent<Monster_Debuff>().Poison_Debuff((int)(GetComponent<Set_Damage>().Damage() * 0.2f));
            }
            
        }
    }
}
