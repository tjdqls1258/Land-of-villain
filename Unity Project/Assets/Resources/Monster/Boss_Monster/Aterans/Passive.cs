using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passive : MonoBehaviour
{
    public GameObject Skill;

    GameObject Player;
    float x;
    float y;
    // Start is called before the first frame update
    void Awake()
    {
        Player = GameObject.Find("Player");
        x = 0;
        y = 0;

        InvokeRepeating("Passives", 0.5f, 0.2f);
    }


    void Passives()
    {
        x = Random.Range(-0.7f , 0.7f);
        y = Random.Range(-0.7f , 0.7f);

        GameObject GOGO_Run = Instantiate(Skill, Player.transform.position + new Vector3(x, y, 0), Quaternion.identity);
        int a = 1 ;
        GOGO_Run.GetComponent<Skill_damage>().Set_Damage(gameObject.GetComponent<Monster_stats>().damage);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
