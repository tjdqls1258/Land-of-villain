using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_quit : MonoBehaviour
{
    [SerializeField] private GameObject QuitUI;

    public void quityes()
    {
        Debug.Log("게임종료");
        Application.Quit();
    }

    public void quitno()
    {
        QuitUI.SetActive(false);
    }
}
