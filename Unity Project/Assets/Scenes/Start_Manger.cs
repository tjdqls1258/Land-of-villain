using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Start_Manger : MonoBehaviour
{
    GameObject SceneManger;
    public Slider Save_slider_BGM;
    public Slider Save_slider_Sound;
    public GameObject Setting;
    public GameObject Help;
    public GameObject Credits;
    public AudioSource audioSource;
    void Awake()
    {
        SceneManger = GameObject.Find("SceneManger");
        Setting_On();
    }

    public void change_Scene(string Scene)
    {
        SceneManger.GetComponent<SceneChanger>().Set_Next_Scene(Scene);
        SceneManager.LoadScene("Loading");
    }

    public void Setting_On()
    {
        Save_slider_Sound.value = PlayerPrefs.GetFloat("E_Sound_Slider");
        Save_slider_BGM.value = PlayerPrefs.GetFloat("B_Sound_Slider");
    }

    public void Save_Sound()
    {
        audioSource.volume = Save_slider_BGM.value;
        PlayerPrefs.SetFloat("B_Sound", audioSource.volume);
        PlayerPrefs.SetFloat("B_Sound_Slider", Save_slider_BGM.value);
        
    }
    public void Save_E_Sound()
    {
        PlayerPrefs.SetFloat("E_Sound_Slider", Save_slider_Sound.value);
    }
    public void OnSetting()
    {
        Setting.SetActive(true);
    }
    public void ExitSetting()
    {
        Setting.SetActive(false);
    }
    public void OnHelp()
    {
        Help.SetActive(true);
    }
    public void ExitHelp()
    {
        Help.SetActive(false);
    }
    public void OnCredit()
    {
        Credits.SetActive(true);
    }
    public void ExitCredit()
    {
        Credits.SetActive(false);
    }
    public void Game_Exit()
    {
        Application.Quit();
    }
}
