using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stage_Text_Fade : MonoBehaviour
{
    private Text CurrentScoretext;
    Player_Stat player_stat;

    private Text text;

    void Awake()
    {
        CurrentScoretext = gameObject.GetComponent<Text>();
        player_stat = GameObject.Find("Player").GetComponent<Player_Stat>();
        text = GetComponent<Text>();    
    }

    void Update()
    {
        CurrentScoretext.text = "Stage " + player_stat.N_Stages.ToString();
    }

    public IEnumerator FadeTextToZero()
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
        while (text.color.a > 0.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / 2.0f));
            yield return null;
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StartCoroutine("FadeTextToZero");
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}