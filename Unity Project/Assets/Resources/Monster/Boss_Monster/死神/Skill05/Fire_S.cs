using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_S : MonoBehaviour
{
    public GameObject Skill;
    Vector3 vec;
    // Start is called before the first frame update
    void Awake()
    {
        vec = new Vector3(0, -0.32f, 0);
        Invoke("Instances", 0.7f);
    }
    void Instances()
    {
        GameObject Skills =  Instantiate(Skill, transform.position, Quaternion.identity);
        Skills.GetComponent<Skill_damage>().Set_Damage(Skills.GetComponent<Skill_damage>().Damage());
        if (transform.position.y > -10)
        {
            GameObject Selfs = Instantiate(gameObject, transform.position + vec, Quaternion.identity);
            Skills.GetComponent<Skill_damage>().Set_Damage(Skills.GetComponent<Skill_damage>().Damage());
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if(GameObject.Find("死神(Clone)") == null)
        {
            Destroy(gameObject);
        }
    }
}
