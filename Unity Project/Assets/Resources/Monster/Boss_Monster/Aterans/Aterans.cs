using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aterans : MonoBehaviour
{
    public GameObject[] Skill_Prefabs;
    public GameObject Dangers;
    public GameObject Player;

    int selection;

    public bool Patan = false;

    public Animator animator;

    public void Start()
    {

        Player = GameObject.Find("Player");
        animator = GetComponent<Animator>();
        //Paten1();
    }
    private void Update()
    {
        if(!Patan)
        {
            Skill_01();
        }
    }

    void Skill_01() //무조건 플레이어를 조준하는 방식
    {
        selection = Random.Range(0, Skill_Prefabs.Length);
        animator.SetBool("Paten"+(selection+1).ToString(), true);
        Patan = true;
        GameObject Prefab = Skill_Prefabs[selection];

        Instantiate(Dangers, Player.transform.position, Quaternion.identity);
        Dangers.GetComponent<Danger>().Patan_Ative(Prefab, gameObject.GetComponent<Monster_stats>().give_damage(), Player.transform.position, 0.45f);

        
        StartCoroutine("Next_Patan");

    }
    IEnumerator Next_Patan()
    {
        yield return new WaitForSeconds(1f);
        animator.SetBool("Paten" + (selection + 1).ToString(), false);
        yield return new WaitForSeconds(.1f);
        Patan = false;
    }
}
