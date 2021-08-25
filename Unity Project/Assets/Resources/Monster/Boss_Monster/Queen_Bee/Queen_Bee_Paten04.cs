using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen_Bee_Paten04 : MonoBehaviour
{
    public GameObject Bullte;
    // Start is called before the first frame update
    private void Awake()
    {
        StartCoroutine("ATK");
    }
    IEnumerator ATK()
    {
        for (int i = 0; i < 18; i++)
        {
            GameObject Bulltes = Instantiate(Bullte, transform.position, transform.rotation);
            Bulltes.GetComponent<Set_Chiled>().Set_all_Bullte(GetComponent<Skill_damage>().Damage());
            transform.Rotate(new Vector3(0, 0, 10));
            yield return new WaitForSeconds(.1f);
        }
    }

}
