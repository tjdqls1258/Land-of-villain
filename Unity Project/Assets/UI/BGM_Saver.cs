using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BGM_Saver : MonoBehaviour
{
    public Slider Save_slider;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Awake()
    {
        this.audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefs.GetFloat("B_Sound");
        Save_slider.value = PlayerPrefs.GetFloat("B_Sound_Slider");
    }
    public void save_sound_Setting()
    {
        PlayerPrefs.SetFloat("B_Sound", audioSource.volume);
        PlayerPrefs.SetFloat("B_Sound_Slider", Save_slider.value);
    }
}
