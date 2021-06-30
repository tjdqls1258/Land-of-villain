using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public GameObject Player;
    //public GameObject[] Monster;
    public List<GameObject> FoundObjects;
    public string stage;

    private int monsternum;

    // Start is called before the first frame update
    void Start()
    {
        FoundObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag("Monster"));
        monsternum = FoundObjects.Count;
        //Monster = GameObject.FindGameObjectsWithTag("Monster");
    }

    // Update is called once per frame
    void Update()
    {
        if(monsternum <= 0)
        {
            SceneManager.LoadScene(stage);
            SceneManager.MoveGameObjectToScene(Player, SceneManager.GetSceneByName(stage));
        }
    }

    public void monsterdead()
    {
        monsternum -= 1;
    }
}
