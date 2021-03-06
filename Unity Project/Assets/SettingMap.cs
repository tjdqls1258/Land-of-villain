using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingMap : MonoBehaviour
{
    Player_Stat player_state;

    // Start is called before the first frame update
    void Awake()
    {
        player_state = GameObject.Find("Player").GetComponent<Player_Stat>();
        if ((player_state.N_Stages % 36) >= 0)
        {    
            transform.Find("Stage01").gameObject.SetActive(true);
            transform.Find("Stage02").gameObject.SetActive(false);
        }
        if ((player_state.N_Stages % 36) >= 12)
        {
            transform.Find("Stage01").gameObject.SetActive(false);
            transform.Find("Stage02").gameObject.SetActive(true);
        }
        
    }
}
