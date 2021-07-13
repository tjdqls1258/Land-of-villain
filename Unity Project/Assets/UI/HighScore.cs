using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    private Text Highscoretext;
    Player_Stat player_stat;

    // Start is called before the first frame update
    void Awake()
    {
        Highscoretext = gameObject.GetComponent<Text>();
        player_stat = GameObject.Find("Player").GetComponent<Player_Stat>();
    }

    // Update is called once per frame
    void Update()
    {
        Highscoretext.text = "HighScore : " + player_stat.N_Stages.ToString() + " stage";
    }
}
