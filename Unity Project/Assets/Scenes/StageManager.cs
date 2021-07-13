﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public GameObject Player;
    public GameObject Player_die_UI;
    public List<GameObject> FoundObjects;
    public string stage;   

    private int monsternum;
    private bool scenechanger = false;

    public GameObject Gate;
    private bool isgate = false;
    public bool clear;

    public GameObject[] Monster_Prefabs;

    private List<GameObject> Monster = new List<GameObject>();

    private int Monster_Many;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        Monster_Many = Random.Range(3, 25);

        for(int i= 0; i< Monster_Many; ++i)
        {
            Spawn();
        }
        FoundObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag("Monster"));
        monsternum = FoundObjects.Count;
        Player.GetComponent<SkillCooldown>().Load_New_Stage();
        Player_die_UI = Player.transform.Find("Play_UI").transform.Find("Player_die_UI").gameObject;
    }

    void Spawn()
    {
        int selection = Random.Range(0, Monster_Prefabs.Length);

        GameObject Prefab = Monster_Prefabs[selection];

        Vector3 spawnPos = GetRandomPosition();

        GameObject instance = Instantiate(Prefab, spawnPos, Quaternion.identity);
        Monster.Add(instance);

    }

    private Vector3 GetRandomPosition()
    {
        int a = Random.Range(0, 3);
        Vector3 basePosition = transform.position;

        float PosX = basePosition.x + Random.Range(-3, 3);
        float PosY = basePosition.y + Random.Range(-3, 3);
        
        if(PosX < 0)
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

        Vector3 spawnPos = new Vector3(PosX, PosY,0f);

        return spawnPos;
    }


    // Update is called once per frame
    void Update()
    {
        if (Player != null)
        {
            clear = Player.GetComponent<Player_Status>().isclear;
            if ((monsternum <= 0) && (isgate == false))
            {
                Instantiate(Gate, Player.transform.position + (Vector3.up)
                    , Quaternion.identity);
                isgate = true;
            }
            if ((clear == true) && (scenechanger == false))
            {
                SceneManager.LoadScene(stage);
                scenechanger = true;
            }
            if(Player.GetComponent<Player_Stat>().Get_P_State(1) <= 0)
            {
                Player_die_UI.SetActive(true);
            }
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {     
        isgate = false;
        scenechanger = false;
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void monsterdead()
    {
        monsternum -= 1;
    }

    public void ReturnToStart()
    {
        SceneManager.LoadScene("Start_Secen");
        Destroy(Player.gameObject);
        Player_die_UI.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene("TestSecen");
        Destroy(Player.gameObject);
        Player_die_UI.SetActive(false);
    }
}