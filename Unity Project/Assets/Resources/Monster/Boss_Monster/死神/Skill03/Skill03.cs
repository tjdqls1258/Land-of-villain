using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill03 : MonoBehaviour
{

    public GameObject Bullte;
    int Damage_s;

    void Awake()
    {
        StartCoroutine("ATK_5");
    }
    IEnumerator ATK_5()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject Bulltes = Instantiate(Bullte, transform.position, Quaternion.identity);
            Bulltes.GetComponent<Skill_damage>().Set_Damage(GetComponent<Skill_damage>().Damage());
            yield return new WaitForSeconds(.6f);
        }
        Destroy(gameObject);
    }
    public void Set_Damage(int dam)
    {
        this.Damage_s = dam;
    }
}
