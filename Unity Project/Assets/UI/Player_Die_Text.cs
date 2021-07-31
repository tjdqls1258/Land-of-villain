using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Die_Text : MonoBehaviour
{
    [SerializeField]
    private Text HighScoreText;
    [SerializeField]
    private Text CurrentScoreText;

    private GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText();
    }

    void ScoreText()
    {
        HighScoreText.text = "HighScore : " + Player.GetComponent<Player_Stat>().Save_Stages.ToString() + " Stage ";

        CurrentScoreText.text = "CurrentScore : " + Player.GetComponent<Player_Stat>().N_Stages.ToString() + " Stage ";
    }
}
