using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hp_Bar : MonoBehaviour
{
    public Image HealthBar;     // 현재체력 이미지와 연결
    public Text HealthText;     // 현재체력 텍스트와 연결
    public GameObject Player;

    public void Awake()
    {
        Player.GetComponent<Player_Stat>().Get_P_State(0);
    }

    private void Update()
    {
        // 플레이어의 현재 체력을 체력바와 동기화
        // 현재체력 이미지 슬라이드(0 ~ 1의 값으로 표현) = 현재체력 / 최대체력
        HealthBar.fillAmount = (float)Player_Status.health / Player_Status.healthMax;
        // 현재체력 텍스트에 체력값을 문자열 형태로 출력
        HealthText.text = Player_Status.health.ToString();
    }

    public void Damage(int Dam)
    {
        HealthText.text = (Player.GetComponent<Player_Stat>().Get_P_State(1)).ToString();
        //100부분 플레이어 HP로 치완
    }
}
