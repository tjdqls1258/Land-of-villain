using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private GameObject QuitUI;
    [SerializeField] private GameObject ReturnToMenuUI;

    public void PauseBtn()
    {
        if (!GameManager.isPause)
        {
            GameManager.isPause = true;
            pauseUI.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    public void ResumeBtn()
    {
        if (GameManager.isPause)
        {
            GameManager.isPause = false;
            pauseUI.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }

    public void ReturnToMenuBtn()
    {
        ReturnToMenuUI.SetActive(true);
    }

    public void QuitBtn()
    {
        QuitUI.SetActive(true);
    }
}