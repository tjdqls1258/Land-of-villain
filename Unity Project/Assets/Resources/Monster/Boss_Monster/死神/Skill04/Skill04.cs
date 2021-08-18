using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill04 : MonoBehaviour
{
    public GameObject Danger_signe;
    public GameObject Skill01s;
    void Awake()
    {
        StartCoroutine("Do_It");
    }
    IEnumerator Do_It()
    {
        GameObject Player = GameObject.Find("Player");

        GameObject Danger_Singes = Instantiate(Danger_signe, Player.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        GameObject.Find("死神(Clone)").transform.position = Danger_signe.transform.position;
        GameObject Skill01ss = Instantiate(Skill01s, Danger_signe.transform.position, Quaternion.identity);
        Skill01ss.GetComponent<Skill_damage>().Set_Damage(gameObject.GetComponent<Skill_damage>().Damage());
        Destroy(Danger_signe);
        Destroy(gameObject);
    }
}
