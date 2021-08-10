using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen_Bee_Paten03 : MonoBehaviour
{
    public GameObject Bullte;
    // Start is called before the first frame update
    void Awake()
    {
        GameObject Bulltes = Instantiate(Bullte, transform.position, Quaternion.identity);
        Bullte.GetComponent<Skill_damage>().Set_Damage(GetComponent<Skill_damage>().Damage());
    }

}
