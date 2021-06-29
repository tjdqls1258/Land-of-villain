using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_Manger : MonoBehaviour
{
    GameObject SceneManger;
    void Awake()
    {
        SceneManger = GameObject.Find("SceneManger");
    }

    public void change_Scene(string Scene)
    {
        SceneManger.GetComponent<SceneChanger>().Set_Next_Scene(Scene);
        SceneManager.LoadScene("Loading");
    }
}
