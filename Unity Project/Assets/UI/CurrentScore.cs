using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentScore : MonoBehaviour
{
    private Text CurrentScoretext;
    Player_Stat player_stat;

    // Start is called before the first frame update
    void Awake()
    {
        CurrentScoretext = gameObject.GetComponent<Text>();
        player_stat = GameObject.Find("Player").GetComponent<Player_Stat>();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentScoretext.text = "CurrentScore : " + player_stat.N_Stages.ToString() + " stage";
    }
}
