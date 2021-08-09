using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dendallia_Paten : MonoBehaviour
{
    public GameObject[] Skill_Prefabs;
    public GameObject Dangers;
    public GameObject Player;

    public GameObject[] Spwan_Monster;

    int selection;

    public bool Patan = false;

    public Animator animator;

    GameObject Prefab;

    public void Start()
    {

        Player = GameObject.Find("Player");
        animator = GetComponent<Animator>();
        selection = Random.Range(0, Skill_Prefabs.Length);
        Prefab = Skill_Prefabs[selection];
        //Paten1();
    }
    private void Update()
    {
        if (!Patan)
        {
            Patan = true;
            switch (Prefab.GetComponent<Skill_damage>().Skill_type)
            {
                case 0:
                    Skill_01();
                    break;
                case 1:
                    Skill_02();
                    break;
                case 2:
                    Skill_03();
                    break;
                case 3:
                    Skill_04();
                    break;
                default:
                    break; 
            }
        }
    }

    void Skill_01() //무조건 플레이어를 조준하는 방식
    {
        animator.SetBool("Paten" + (selection + 1).ToString(), true);

        GameObject Prefabs = Skill_Prefabs[selection];
        GameObject Warring = Instantiate(Dangers, Player.transform.position, Quaternion.identity);
        Warring.GetComponent<Danger>().Patan_Ative(Prefabs, gameObject.GetComponent<Monster_stats>().give_damage(), Player.transform.position);


        StartCoroutine("Next_Patan");

    }
    void Skill_02() //플레이어에게 순간이동
    {
        animator.SetBool("Paten" + (selection + 1).ToString(), true);

        GameObject Prefabs = Skill_Prefabs[selection];  
        GameObject Warring = Instantiate(Dangers, Player.transform.position, Quaternion.identity);
        Warring.GetComponent<Danger>().Patan_Ative(Prefabs, gameObject.GetComponent<Monster_stats>().give_damage(), Player.transform.position);

        StartCoroutine("Warp_To_Player", Warring.transform.position);
    }
    void Skill_03()
    {
        animator.SetBool("Paten" + (selection + 1).ToString(), true);
        GameObject stageManger = GameObject.Find("StageManager");

        int i = Random.Range(0, Spwan_Monster.Length);
        Instantiate(Spwan_Monster[i],this.gameObject.transform.position,Quaternion.identity);

        stageManger.GetComponent<StageManager>().Monster_Check();
        StartCoroutine("Base");
    }
    void Skill_04() //테스트용 (여왕벌)
    {
        animator.SetBool("Paten" + (selection + 1).ToString(), true);
        GameObject stageManger = GameObject.Find("StageManager");

        Instantiate(Prefab, this.gameObject.transform.position, Quaternion.identity);

        StartCoroutine("Base2");
    }
    IEnumerator Base2()
    {
        yield return new WaitForSeconds(Prefab.GetComponent<Skill_damage>().Skill_CollTime);
        animator.SetBool("Paten" + (selection + 1).ToString(), false);

        yield return new WaitForSeconds(.1f);
        selection = Random.Range(0, Skill_Prefabs.Length);
        Prefab = Skill_Prefabs[selection];
        Patan = false;

    }
    IEnumerator Base()
    {
        yield return new WaitForSeconds(Prefab.GetComponent<Skill_damage>().Skill_CollTime);
        animator.SetBool("Paten" + (selection + 1).ToString(), false);

        yield return new WaitForSeconds(.1f);
        selection = Random.Range(0, Skill_Prefabs.Length);
        Prefab = Skill_Prefabs[selection];
        Patan = false;

    }
    IEnumerator Warp_To_Player(Vector3 Warp_Point)
    {
        yield return new WaitForSeconds(Prefab.GetComponent<Skill_damage>().Skill_CollTime);
        animator.SetBool("Paten" + (selection + 1).ToString(), false);
        gameObject.transform.position = Warp_Point;

        yield return new WaitForSeconds(.1f);
        selection = Random.Range(0, Skill_Prefabs.Length);
        Prefab = Skill_Prefabs[selection];
        Patan = false;

    }
        //이거 몬스터 공격 방식에 따라 위치선정하면 될듯?
    IEnumerator Next_Patan()
    {
        yield return new WaitForSeconds(Prefab.GetComponent<Skill_damage>().Skill_CollTime);
        animator.SetBool("Paten" + (selection + 1).ToString(), false);
        yield return new WaitForSeconds(.1f);
        selection = Random.Range(0, Skill_Prefabs.Length);
        Prefab = Skill_Prefabs[selection];
        Patan = false;
    }
}
