using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    private Text Highscoretext;
    Player_Stat player_stat;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Highscoretext.text = player_stat.GetComponent<Player_Stat>().N_Stages.ToString();
    }
}
