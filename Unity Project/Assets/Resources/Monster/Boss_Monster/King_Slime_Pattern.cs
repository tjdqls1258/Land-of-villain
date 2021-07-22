using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King_Slime_Pattern : MonoBehaviour
{
    [SerializeField]
    private GameObject King_Slime;
    [SerializeField]
    private GameObject Slime;
    private float HP;

    private bool phase1 = false;
    private bool phase2 = false;
    private bool phase3 = false;

    private List<GameObject> Monster = new List<GameObject>();

    // Start is called before the first frame update
    void Awake()
    {
        HP = GetComponent<Monster_stats>().Hp;
    }

    // Update is called once per frame
    void Update()
    {
        if((HP <= HP*0.75) && (HP > HP * 0.5) && (phase1 == false))
        {
            phase1 = true;
            this.transform.localScale = new Vector2(0.75f, 0.75f);
            for(int i = 0; i<5; i++)
            {
                Spawn_Slime();
            }
        }
        else if((HP <= HP * 0.5) && (HP > HP * 0.25) && (phase2 == false))
        {
            phase2 = true;
            this.transform.localScale = new Vector2(0.5f, 0.5f);
            for (int i = 0; i < 10; i++)
            {
                Spawn_Slime();
            }
        }
        else if((HP <= HP * 0.25) && (HP > 0) && (phase3 == false))
        {
            phase3 = true;
            this.transform.localScale = new Vector2(0.25f, 0.25f);
            for (int i = 0; i < 15; i++)
            {
                Spawn_Slime();
            }
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
