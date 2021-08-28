using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen_Bee_Paten03 : MonoBehaviour
{
    public GameObject Bullte;
    GameObject Bulltes;
    // Start is called before the first frame update
    void Awake()
    {
        Bulltes = Instantiate(Bullte, transform.position, Quaternion.identity);
        Invoke("SetDam", 0.1f);
    }
    void SetDam()
    {
        Bulltes.GetComponent<Setting_Skill_M>().Set_all_Bullte(GetComponent<Skill_damage>().Damage());
    }

}
