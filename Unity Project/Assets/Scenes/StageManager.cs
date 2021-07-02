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

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        FoundObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag("Monster"));
        monsternum = FoundObjects.Count;
    }

    // Update is called once per frame
    void Update()
    {
        clear = Player.GetComponent<Player_Status>().isclear;
        if ((monsternum <= 0) && (isgate == false))
        {
            Instantiate(Gate, new Vector3(0, 9.5f, 0), Quaternion.identity);
            isgate = true;
        }
        if ((clear == true) && (scenechanger == false))
        {
            SceneManager.LoadScene(stage);
            SceneManager.MoveGameObjectToScene(Player, SceneManager.GetSceneByName(stage));
            scenechanger = true;
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