using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingSceneManger : MonoBehaviour
{
    public Slider slider; // 로딩 바

    private float time; // 로딩시간
    private GameObject ScenManger;

    void Start()
    {
        StartCoroutine(LoadAsynSceneCoroutine());
    }
    private void Awake()
    {
        ScenManger = GameObject.Find("SceneManger");
        slider.value = 0;
    }
    IEnumerator LoadAsynSceneCoroutine()
    {

        AsyncOperation operation = SceneManager.LoadSceneAsync(ScenManger.GetComponent<SceneChanger>().Get_Next_Scene());
        operation.allowSceneActivation = false;
        while (!operation.isDone)
        {

            time = +Time.time;
            slider.value = time / 10f;
            
            if (time > 10)
            {
                operation.allowSceneActivation = true;
            }
            yield return null;
        }
    }

}
