using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin_Shaman_Pattern : MonoBehaviour
{
    public GameObject Goblin_Skill;
    public GameObject Dangers;
    public GameObject Player;
    public GameObject Goblins;

    public bool Goblin_ispattern = false;
    bool 광폭화;

    // Start is called before the first frame update
    void Start()
    {
        광폭화 = false;
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!Goblin_ispattern)
        {
            Goblin_Pattern();
            if (GetComponent<Monster_stats>().Hp < (GetComponent<Monster_stats>().current_HP * 0.3f))
            {
                if (!광폭화)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Spawn_Goblin();
                    }
                    광폭화 = true;
                }
            }
        }
    }
    private void Spawn_Goblin()
    {
        Vector3 spawnPos = GetRandomPosition();

        GameObject instance = Instantiate(Goblins, spawnPos, Quaternion.identity);
    }
    private Vector3 GetRandomPosition()
    {
        int a = Random.Range(0, 3);
        Vector3 basePosition = this.transform.position;

        float PosX = basePosition.x + Random.Range(-3, 3);
        float PosY = basePosition.y + Random.Range(-3, 3);

        if (PosX < 0)
        {
            PosX -= 0.5f;
        }
        else
        {
            PosX += 0.5f;
        }

        if (PosY < 0)
        {
            PosY -= 0.5f;
        }
        else
        {
            PosY += 0.5f;
        }

        Vector3 spawnPos = new Vector3(PosX, PosY, 0f);

        return spawnPos;
    }
    void Goblin_Pattern()
    {
        StartCoroutine("Skill");
    }

    IEnumerator Skill()
    {
        Goblin_ispattern = true;
        Vector3 Danger = Player.gameObject.transform.position;

        
        if(광폭화)
        {
            GameObject Danger_check = Instantiate(Dangers, Danger, Quaternion.identity);
            Danger_check.GetComponent<Danger>().Patan_Ative(Goblin_Skill, GetComponent<Monster_stats>().give_damage(), Danger, 0.4f);
            yield return new WaitForSeconds(0.3f);
            GameObject Danger_check_n = Instantiate(Dangers, Danger + new Vector3(0, 0.32f, 0), Quaternion.identity);
            GameObject Danger_check_w = Instantiate(Dangers, Danger - new Vector3(0.32f, 0, 0), Quaternion.identity);
            GameObject Danger_check_e = Instantiate(Dangers, Danger + new Vector3(0.32f, 0, 0), Quaternion.identity);
            GameObject Danger_check_s = Instantiate(Dangers, Danger - new Vector3(0, 0.32f, 0), Quaternion.identity);
            Danger_check_e.GetComponent<Danger>().Patan_Ative(Goblin_Skill, GetComponent<Monster_stats>().give_damage(), Danger + new Vector3(0.32f, 0, 0), 0.3f);
            Danger_check_n.GetComponent<Danger>().Patan_Ative(Goblin_Skill, GetComponent<Monster_stats>().give_damage(), Danger + new Vector3(0, 0.32f, 0), 0.3f);
            Danger_check_w.GetComponent<Danger>().Patan_Ative(Goblin_Skill, GetComponent<Monster_stats>().give_damage(), Danger - new Vector3(0.32f, 0, 0), 0.3f);
            Danger_check_s.GetComponent<Danger>().Patan_Ative(Goblin_Skill, GetComponent<Monster_stats>().give_damage(), Danger - new Vector3(0, 0.32f, 0), 0.3f);

            GameObject Danger_check_n_ = Instantiate(Dangers, Danger + new Vector3(0.32f, 0.32f, 0), Quaternion.identity);
            GameObject Danger_check_w_ = Instantiate(Dangers, Danger + new Vector3(0.32f, -0.32f, 0), Quaternion.identity);
            GameObject Danger_check_e_ = Instantiate(Dangers, Danger + new Vector3(-0.32f, -0.32f, 0), Quaternion.identity);
            GameObject Danger_check_s_ = Instantiate(Dangers, Danger + new Vector3(-0.32f, 0.32f, 0), Quaternion.identity);
            Danger_check_w_.GetComponent<Danger>().Patan_Ative(Goblin_Skill, GetComponent<Monster_stats>().give_damage(), Danger + new Vector3(0.32f, -0.32f, 0), 0.3f);
            Danger_check_n_.GetComponent<Danger>().Patan_Ative(Goblin_Skill, GetComponent<Monster_stats>().give_damage(), Danger + new Vector3(0.32f, 0.32f, 0), 0.3f);
            Danger_check_e_.GetComponent<Danger>().Patan_Ative(Goblin_Skill, GetComponent<Monster_stats>().give_damage(), Danger + new Vector3(-0.32f, -0.32f, 0), 0.3f);
            Danger_check_s_.GetComponent<Danger>().Patan_Ative(Goblin_Skill, GetComponent<Monster_stats>().give_damage(), Danger + new Vector3(-0.32f, 0.32f, 0), 0.3f);
        }
        else
        {
            GameObject Danger_check = Instantiate(Dangers, Danger, Quaternion.identity);
            Danger_check.GetComponent<Danger>().Patan_Ative(Goblin_Skill, GetComponent<Monster_stats>().give_damage(), Danger, 0.5f);
            yield return new WaitForSeconds(0.3f);
            GameObject Danger_check_n = Instantiate(Dangers, Danger + new Vector3(0, 0.32f, 0), Quaternion.identity);
            GameObject Danger_check_w = Instantiate(Dangers, Danger - new Vector3(0.32f, 0, 0), Quaternion.identity);
            GameObject Danger_check_e = Instantiate(Dangers, Danger + new Vector3(0.32f, 0, 0), Quaternion.identity);
            GameObject Danger_check_s = Instantiate(Dangers, Danger - new Vector3(0, 0.32f, 0), Quaternion.identity);
            Danger_check_e.GetComponent<Danger>().Patan_Ative(Goblin_Skill, GetComponent<Monster_stats>().give_damage(), Danger + new Vector3(0.32f, 0, 0), 0.5f);
            Danger_check_n.GetComponent<Danger>().Patan_Ative(Goblin_Skill, GetComponent<Monster_stats>().give_damage(), Danger + new Vector3(0, 0.32f, 0), 0.5f);
            Danger_check_w.GetComponent<Danger>().Patan_Ative(Goblin_Skill, GetComponent<Monster_stats>().give_damage(), Danger - new Vector3(0.32f, 0, 0), 0.5f);
            Danger_check_s.GetComponent<Danger>().Patan_Ative(Goblin_Skill, GetComponent<Monster_stats>().give_damage(), Danger - new Vector3(0, 0.32f, 0), 0.5f);
        }
        yield return new WaitForSeconds(1.0f);

        Goblin_ispattern = false;
    }
}
