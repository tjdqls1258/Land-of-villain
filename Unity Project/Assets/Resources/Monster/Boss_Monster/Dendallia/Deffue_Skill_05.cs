using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deffue_Skill_05 : MonoBehaviour
{
    public GameObject Skill05;
    // Start is called before the first frame update
    void Awake()
    {
        transform.position = GameObject.Find("Player").transform.position;
        Invoke("Deffue", 0.5f);
    }


    void Deffue()
    {
        GameObject Skill = Instantiate(Skill05, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
