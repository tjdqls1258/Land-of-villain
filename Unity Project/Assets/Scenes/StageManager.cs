using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public GameObject Player;
    public List<GameObject> FoundObjects;
    public string stage;   

    private int monsternum;
    private bool scenechanger = false;

    public GameObject Gate;
    private bool isgate = false;
    public bool clear;

    public GameObject[] Monster_Prefabs;
    public GameObject[] Boss_Prefabs;

    private List<GameObject> Monster = new List<GameObject>();

    private int Monster_Many;
    // Start is called before the first frame update
    void Start()
    {
        
        Player = GameObject.Find("Player");
        if(Player == null)
        {
            Player = (GameObject)Resources.Load("Player/Player");
            Instantiate(Player, Vector3.zero, Quaternion.identity);
        }
        Monster_Many = Random.Range(3, 25);

        int currentStage = Player.GetComponent<Player_Stat>().N_Stages;
        if ((currentStage % 5) == 0)
        {
            GameObject Boss = Boss_Prefabs[((currentStage/5)-1)];
            Vector3 spawnPos = GetRandomPosition();

            GameObject instance = Instantiate(Boss, spawnPos, Quaternion.identity);
            Monster.Add(instance);
            Monster_Check();
        }
        else if(((currentStage % 5) == 1) && (currentStage != 1))
        {
            //상점 
            Instantiate(Resources.Load("Item/Item_Shop_UI/Canvas"), new Vector2(this.transform.position.x,this.transform.position.y), Quaternion.identity);

        }
        else
        {
            for (int i = 0; i < Monster_Many; ++i)
            {
                Spawn();
            }
            Monster_Check();
        }
    
    }

    public void Monster_Check()
    {
        FoundObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag("Monster"));
        monsternum = FoundObjects.Count;
        Player.GetComponent<SkillCooldown>().Load_New_Stage();
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
}