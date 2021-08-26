using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingMap : MonoBehaviour
{
    Player_Stat player_state;
    public GameObject Cam_BGM;
    
    public AudioClip Sound;
    // Start is called before the first frame update
    void Awake()
    {
        player_state = GameObject.Find("Player").GetComponent<Player_Stat>();
        if (player_state.N_Stages >= 0)
        {
            transform.Find("Stage01").gameObject.SetActive(true);
        }
        if (player_state.N_Stages > 11)
        {
            transform.Find("Stage01").gameObject.SetActive(false);
            transform.Find("Stage02").gameObject.SetActive(true);
            Cam_BGM.GetComponent<AudioSource>().clip = Sound;
            Cam_BGM.GetComponent<AudioSource>().Play();
        }
    }
}
