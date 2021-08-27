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
        Vector2 target = Player.transform.position;
        GameObject Danger_Singes = Instantiate(Danger_signe, Player.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        Destroy(Danger_Singes);
        if (GameObject.Find("死神(Clone)") != null)
        {
            GameObject.Find("死神(Clone)").transform.position = target;
        }
        yield return new WaitForSeconds(0.1f);
        GameObject Skill01ss = Instantiate(Skill01s, target, Quaternion.identity);
        Skill01ss.GetComponent<Skill_damage>().Set_Damage(gameObject.GetComponent<Skill_damage>().Damage());
        
        Destroy(gameObject);
    }
}
