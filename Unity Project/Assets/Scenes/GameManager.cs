using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // 싱글턴을 할당할 전역 변수

    public static bool isPause = false; // 일시정지 상태를 체크할 변수

    private void Awake()
    {
        if(instance == null)
        { // 싱글턴 변수에 할당된 값이 없으면
            instance = this; // 이 게임 매니저를 할당
        }
        else
        { // 싱글턴 변수에 할당된 값이 있으면
            // 씬에 두 개 이상의 GameManager가 생기지 않도록
            Debug.LogWarning("씬에 두 개 이상의 게임 매니저 존재");
            Destroy(gameObject); // 이 게임 매니저를 파괴
        }
    }
}