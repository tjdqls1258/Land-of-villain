using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATK_Rock : MonoBehaviour
{
    public GameObject ATks;
    // Start is called before the first frame update
    void Awake()
    {
        Invoke("ATK",0.5f);
    }

    void ATK()
    {
        GameObject atk =  Instantiate(ATks, transform.position, Quaternion.identity);
        atk.GetComponent<Skill_damage>().Set_Damage(GetComponent<Skill_damage>().Damage());
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
