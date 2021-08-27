using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 死神_Passive : MonoBehaviour
{
    public GameObject Passive_Skill;
    void Awake()
    {
        StartCoroutine("Skills");
        
    }

    IEnumerator Skills()
    {
        while (gameObject != null)
        {
            float distance = -10.0f;
            while (distance <= 10.0f)
            {
                GameObject Passive_Skill_ = Instantiate(Passive_Skill, new Vector3(distance, 10.0f, 0), Quaternion.identity);
                Passive_Skill_.GetComponent<Skill_damage>().Set_Damage(GetComponent<Monster_stats>().damage);
                distance += 0.32f;
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(1f);
        }
        
    }
    
}
