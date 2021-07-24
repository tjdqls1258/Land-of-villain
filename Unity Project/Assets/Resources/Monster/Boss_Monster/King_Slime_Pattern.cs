using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King_Slime_Pattern : MonoBehaviour
{
    [SerializeField]
    private GameObject King_Slime;
    [SerializeField]
    private GameObject Slime;
    private GameObject stagemanager;

    private float HP;
    private float MaxHP;

    private bool phase1 = false;
    private bool phase2 = false;
    private bool phase3 = false;

    private List<GameObject> Monster = new List<GameObject>();

    // Start is called before the first frame update
    void Awake()
    {
        stagemanager = GameObject.Find("StageManager");
        MaxHP = King_Slime.GetComponent<Monster_stats>().Hp;
    }

    // Update is called once per frame
    void Update()
    {
        HP = King_Slime.GetComponent<Monster_stats>().Hp;
        if ((HP <= (MaxHP * 0.75)) && (HP > (MaxHP * 0.5)) && (phase1 == false))
        {           
            phase1 = true;
            this.transform.localScale *= new Vector2(0.75f, 0.75f);
            for (int i = 0; i < 5; i++)
            {
                Spawn_Slime();
            }
            stagemanager.GetComponent<StageManager>().Monster_Check();
        }
        else if((HP <= (MaxHP * 0.5)) && (HP > (MaxHP * 0.25)) && (phase2 == false))
        {
            phase2 = true;
            this.transform.localScale *= new Vector2(0.67f, 0.67f);
            for (int i = 0; i < 10; i++)
            {
                Spawn_Slime();
            }
            stagemanager.GetComponent<StageManager>().Monster_Check();
        }
        else if((HP <= (MaxHP * 0.25)) && (MaxHP > 0) && (phase3 == false))
        {
            phase3 = true;
            this.transform.localScale *= new Vector2(0.5f, 0.5f);
            for (int i = 0; i < 15; i++)
            {
                Spawn_Slime();
            }
            stagemanager.GetComponent<StageManager>().Monster_Check();
        }
    }

    private void Spawn_Slime()
    {
        Vector3 spawnPos = GetRandomPosition();

        GameObject instance = Instantiate(Slime, spawnPos, Quaternion.identity);
        Monster.Add(instance);
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
}
