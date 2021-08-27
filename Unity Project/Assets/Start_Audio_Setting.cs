using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_Audio_Setting : MonoBehaviour
{
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefs.GetFloat("B_Sound");
    }

}
