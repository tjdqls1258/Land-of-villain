using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    string Next_Scene;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void Set_Next_Scene(string Scene)
    {
        Next_Scene = "";
        Next_Scene = Scene;
    }
    public string Get_Next_Scene()
    {
        return Next_Scene;
    }
}
