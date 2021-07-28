using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aterans : MonoBehaviour
{
    public GameObject Skill01, Skill02, Skill03;
    public GameObject Dangers;
    public GameObject Player;

    public bool Patan = false;

    public Animator animator;

    public void Start()
    {
        Dangers = (GameObject)Resources.Load("Monster/Boss_Monster/Aterans/Danger_sign");
        Skill01 = (GameObject)Resources.Load("Monster/Boss_Monster/Aterans/M_Skill01");
        Skill02 = (GameObject)Resources.Load("Monster/Boss_Monster/Aterans/M_Skill02");
        Skill03 = (GameObject)Resources.Load("Monster/Boss_Monster/Aterans/M_Skill03");
        Player = GameObject.Find("Player");
        animator = GetComponent<Animator>();
        Paten1();
    }
    private void Update()
    {
        if(!Patan)
        {
            int patens = Random.Range(1, 4);
            switch (patens)
            {
                case 1:
                    Paten1();
                    break;
                case 2:
                    Paten2();
                    break;
                case 3:
                    Paten3();
                    break;
                default:
                    break;
            }
                

        }
    }
    public void Paten1()
    {
        StartCoroutine("Start_Skill_01");
    }
    public void Paten2()
    {
        StartCoroutine("Start_Skill_02");
    }
    public void Paten3()
    {
        StartCoroutine("Start_Skill_03");
    }
    IEnumerator Start_Skill_01()
    {
        Patan = true;
        animator.SetBool("Paten1", true);
        Vector3 Danger = Player.gameObject.transform.position;

        Instantiate(Dangers, Danger, Quaternion.identity);
        yield return new WaitForSeconds(.25f);
        
        GameObject Skill = Instantiate(Skill01, Danger, Quaternion.identity);
        Skill.GetComponent<Skill_damage>().Set_Damage(
            gameObject.GetComponent<Monster_stats>().give_damage());
        animator.SetBool("Paten1", false);
        yield return new WaitForSeconds(1f);
        Patan = false;
    }
    IEnumerator Start_Skill_02()
    {
        Patan = true;
        animator.SetBool("Paten2", true);
        Vector3 Danger = Player.gameObject.transform.position;

        Instantiate(Dangers, Danger, Quaternion.identity);
        yield return new WaitForSeconds(.25f);

        GameObject Skill = Instantiate(Skill03, Danger, Quaternion.identity);
        Skill.GetComponent<Skill_damage>().Set_Damage(gameObject.GetComponent<Monster_stats>().give_damage());
        animator.SetBool("Paten2", false);
        yield return new WaitForSeconds(1f);
        Patan = false;
    }
    IEnumerator Start_Skill_03()
    {
        Patan = true;
        animator.SetBool("Paten3", true);
        Vector3 Danger = Player.gameObject.transform.position;

        Instantiate(Dangers, Danger, Quaternion.identity);
        yield return new WaitForSeconds(.25f);

        GameObject Skill = Instantiate(Skill02, Danger, Quaternion.identity);
        Skill.GetComponent<Skill_damage>().Set_Damage(gameObject.GetComponent<Monster_stats>().give_damage());
        animator.SetBool("Paten3", false);
        yield return new WaitForSeconds(1f);
        Patan = false;
    }
}
