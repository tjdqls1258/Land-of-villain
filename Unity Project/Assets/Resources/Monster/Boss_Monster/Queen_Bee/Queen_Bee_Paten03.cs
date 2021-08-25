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
        Bulltes.GetComponent<Setting_Skill_M>().Set_all_Bullte(GetComponent<Skill_damage>().Damage());
    }

}
