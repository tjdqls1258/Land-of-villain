using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 死神_Passive2 : MonoBehaviour
{
    GameObject Player;
    public GameObject Passive_Skill2;
    void Awake()
    {
        Player = GameObject.Find("Player");
        StartCoroutine("Skillsss2");
    }

    // Update is called once per frame

    IEnumerator Skillsss2()
    {
        while (gameObject != null)
        {
            Vector3 Rans = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0);
            if (Rans.x <= Player.transform.position.x)
            {
                Rans.x -= 2.0f;
            }
            if (Rans.x >= Player.transform.position.x)
            {
                Rans.x += 2.0f;
            }

            if (Rans.y <= Player.transform.position.y)
            {
                Rans.y -= 2.0f;
            }
            if (Rans.y >= Player.transform.position.y)
            {
                Rans.y += 2.0f;
            }

            GameObject Passive_Skill2_ = Instantiate(Passive_Skill2, Player.transform.position + Rans, Quaternion.identity);
            Passive_Skill2_.GetComponent<Skill_damage>().Set_Damage(GetComponent<Monster_stats>().damage);
            Debug.Log("던짐");
            yield return new WaitForSeconds(2f);
        }
    }
}
