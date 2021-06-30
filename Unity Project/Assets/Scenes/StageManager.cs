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
    private bool scenechanger;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        FoundObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag("Monster"));
        monsternum = FoundObjects.Count;
        scenechanger = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (monsternum <= 0 && scenechanger == false)
        {
            SceneManager.LoadScene(stage, LoadSceneMode.Additive);
            SceneManager.MoveGameObjectToScene(Player, SceneManager.GetSceneByName(stage));
            scenechanger = true;
        }
    }

    public void monsterdead()
    {
        monsternum -= 1;
    }
}