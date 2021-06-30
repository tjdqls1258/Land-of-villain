using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Hp_Bar : MonoBehaviour
{
    public Slider HealBar;
    public Text Hp;
    public GameObject Player;
    public void Awake()
    {
        Player.GetComponent<Player_Stat>().Get_P_State(0);
    }
    public void Damage(int Dam)
    {
        HealBar.value = Player.GetComponent<Player_Stat>().Get_P_State(1) / Player.GetComponent<Player_Stat>().Get_P_State(0); ;
        Hp.text = (Player.GetComponent<Player_Stat>().Get_P_State(1)).ToString();
        //100부분 플레이어 HP로 치완
    }
}
