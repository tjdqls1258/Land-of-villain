using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BGM_Saver : MonoBehaviour
{
    public GameObject Player;
    public Slider Save_slider;
    AudioSource audioSource;

    public AudioClip Sound;
    public AudioClip Sound2;
    // Start is called before the first frame update
    void Awake()
    {
        Player = GameObject.Find("Player");
        this.audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefs.GetFloat("B_Sound");
        Save_slider.value = PlayerPrefs.GetFloat("B_Sound_Slider");
        
    }
    public void save_sound_Setting()
    {
        PlayerPrefs.SetFloat("B_Sound", audioSource.volume);
        PlayerPrefs.SetFloat("B_Sound_Slider", Save_slider.value);
    }
    public void Setting_BGM()
    {
        if ((Player.GetComponent<Player_Stat>().N_Stages % 36) == 1)
        {
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().clip = Sound;
            GetComponent<AudioSource>().Play();
        }
        if ((Player.GetComponent<Player_Stat>().N_Stages % 36) == 12)
        {
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().clip = Sound2;
            GetComponent<AudioSource>().Play();
        }
    }
}
