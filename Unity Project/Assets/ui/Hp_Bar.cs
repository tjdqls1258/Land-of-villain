using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Hp_Bar : MonoBehaviour
{
    public Slider HealBar;
    public Text HP_T;
    public GameObject Player;
    public void Awake()
    {
<<<<<<< Updated upstream
        P_Hp = Player.GetComponent<Player_Stat>().Get_HP();
=======

>>>>>>> Stashed changes
    }
    public void Set_Hp(int Hp)
    {
        HealBar.value = Hp / Player.GetComponent<Player_Stat>().Get_P_State(0);
        HP_T.text = (Hp).ToString();
        //100부분 플레이어 HP로 치완
    }
}
