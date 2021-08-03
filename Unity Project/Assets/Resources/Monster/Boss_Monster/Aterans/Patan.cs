using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patan : MonoBehaviour
{
    public GameObject[] Skill_Prefabs;
    public GameObject Dangers;
    public GameObject Player;

    int selection;

    public bool Patans = false;

    public Animator animator;

    public void Start()
    {

        Player = GameObject.Find("Player");
        animator = GetComponent<Animator>();
        //Paten1();
    }
    private void Update()
    {
        if (!Patans)
        {
            Skill_01();
        }
    }

    void Skill_01() //무조건 플레이어를 조준하는 방식
    {
        selection = Random.Range(0, Skill_Prefabs.Length);
        //animator.SetBool("Paten" + (selection + 1).ToString(), true); //몬스터 애니메이션 작동
        Patans = true;
        GameObject Prefab = Skill_Prefabs[selection];

        Dangers.GetComponent<Danger>().Patan_Ative(Prefab, gameObject.GetComponent<Monster_stats>().give_damage(), Player.transform.position);


        StartCoroutine("Next_Patan");

    }
    IEnumerator Next_Patan()
    {
        yield return new WaitForSeconds(1f);
        //animator.SetBool("Paten" + (selection + 1).ToString(), false); //몬스터 애니메이션 작동
        yield return new WaitForSeconds(.1f);
        Patans = false;
    }
}
