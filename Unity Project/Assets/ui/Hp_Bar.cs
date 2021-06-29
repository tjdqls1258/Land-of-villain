using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Hp_Bar : MonoBehaviour
{
    public Slider HealBar;
    public Text Hp;
    public GameObject Player;
    public float P_Hp;
    public void Start()
    {
        P_Hp = Player.GetComponent<Player_Stats>().Get_HP();
    }
    public void Damage(float Dam)
    {
        HealBar.value -= Dam / 100;
        Hp.text = (P_Hp - Dam).ToString();
        //100부분 플레이어 HP로 치완
    }
}
