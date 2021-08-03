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
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!Goblin_ispattern)
        {
            Goblin_Pattern();
        }
    }

    void Goblin_Pattern()
    {
        StartCoroutine("Skill");
    }

    IEnumerator Skill()
    {
        Goblin_ispattern = true;
        Vector3 Danger = Player.gameObject.transform.position;

        Dangers.GetComponent<Danger>().Patan_Ative(Goblin_Skill, GetComponent<Monster_stats>().give_damage(), Danger);
        yield return new WaitForSeconds(0.3f);
        
        Dangers.GetComponent<Danger>().Patan_Ative(Goblin_Skill, GetComponent<Monster_stats>().give_damage(), Danger + new Vector3(0.32f, 0, 0));
        Dangers.GetComponent<Danger>().Patan_Ative(Goblin_Skill, GetComponent<Monster_stats>().give_damage(), Danger + new Vector3(0, 0.32f, 0));
        Dangers.GetComponent<Danger>().Patan_Ative(Goblin_Skill, GetComponent<Monster_stats>().give_damage(), Danger - new Vector3(0.32f, 0, 0));
        Dangers.GetComponent<Danger>().Patan_Ative(Goblin_Skill, GetComponent<Monster_stats>().give_damage(), Danger - new Vector3(0, 0.32f, 0));
        yield return new WaitForSeconds(1.0f);

        Goblin_ispattern = false;
    }
}
