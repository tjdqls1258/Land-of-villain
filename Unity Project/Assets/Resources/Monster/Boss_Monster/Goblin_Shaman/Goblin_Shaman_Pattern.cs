using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin_Shaman_Pattern : MonoBehaviour
{
    public GameObject Goblin_Skill;
    public GameObject Dangers;
    public GameObject Player;

    public bool Goblin_ispattern = false;

    // Start is called before the first frame update
    void Start()
    {
        Dangers = (GameObject)Resources.Load("Monster/Boss_Monster/Goblin_Shaman/Danger_sign");
        Goblin_Skill = (GameObject)Resources.Load("Monster/Boss_Monster/Goblin_Shaman/M_Skill01");
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Goblin_Pattern();
    }

    void Goblin_Pattern()
    {
        StartCoroutine("Skill");
    }

    IEnumerator Skill()
    {
        Goblin_ispattern = true;
        Vector3 Danger = Player.gameObject.transform.position;

        Instantiate(Dangers, Danger, Quaternion.identity);
        yield return new WaitForSeconds(0.25f);

        Instantiate(Dangers, Danger + new Vector3(0.32f, 0, 0), Quaternion.identity);
        Instantiate(Dangers, Danger + new Vector3(0, 0.32f, 0), Quaternion.identity);
        Instantiate(Dangers, Danger - new Vector3(0.32f, 0, 0), Quaternion.identity);
        Instantiate(Dangers, Danger - new Vector3(0, 0.32f, 0), Quaternion.identity);
        yield return new WaitForSeconds(0.25f);

        GameObject Skill = Instantiate(Goblin_Skill, Danger, Quaternion.identity);
        yield return new WaitForSeconds(0.25f);

        GameObject Skill_w = Instantiate(Goblin_Skill, Danger + new Vector3(0.32f, 0, 0), Quaternion.identity);
        GameObject Skill_n = Instantiate(Goblin_Skill, Danger + new Vector3(0, 0.32f, 0), Quaternion.identity);
        GameObject Skill_e = Instantiate(Goblin_Skill, Danger - new Vector3(0.32f, 0, 0), Quaternion.identity);
        GameObject Skill_s = Instantiate(Goblin_Skill, Danger - new Vector3(0, 0.32f, 0), Quaternion.identity);
        Skill.GetComponent<Skill_damage>().Set_Damage(gameObject.GetComponent<Monster_stats>().give_damage());



        yield return new WaitForSeconds(1f);
        Goblin_ispattern = false;
    }
}
