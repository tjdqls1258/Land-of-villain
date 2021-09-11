using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LodingSound_Manger : MonoBehaviour
{
    public AudioSource audio;
    void Start()
    {
        audio.volume = PlayerPrefs.GetFloat("B_Sound");
    }
}
