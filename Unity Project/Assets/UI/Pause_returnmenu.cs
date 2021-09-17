using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_returnmenu : MonoBehaviour
{
    public GameObject Player;
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private GameObject ReturnToMenuUI;

    public void returnyes()
    {
        GameManager.isPause = false;
        SceneManager.LoadScene("Start_Secen");
        Destroy(Player.gameObject);
        pauseUI.SetActive(false);
        Time.timeScale = 1.0f;
        Debug.Log("load start");
    }

    public void returnno()
    {
        ReturnToMenuUI.SetActive(false);
    }
}
