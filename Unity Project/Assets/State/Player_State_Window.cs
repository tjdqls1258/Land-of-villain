using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player_State_Window : MonoBehaviour
{   //이 코드는 캔버스나, Player_State_Window_UI에 직접 넣는게 아닌 하나의 통합 UI에 넣는 코드임을 고려해서 작성함
    [SerializeField]
    private Text HP;
    [SerializeField]
    private Text STR;
    [SerializeField]
    private Text DEF;
    [SerializeField]
    private Text AGI;
    [SerializeField]
    private Text LUK;
    [SerializeField]
    private Text Money;
    [SerializeField]
    private Text Weapon;
    [SerializeField]
    private Text Armor;
    [SerializeField]
    private Text Hat;
    [SerializeField]
    private Text Ring;

    Player_Stat P_S;
    Player_Item P_I;

    void Start()
    {      
        //일단 플레이어라는 빈 오브젝트안에 Player_Stat 스크립을 넣음.
        P_S = GameObject.Find("Player").GetComponent<Player_Stat>();
        P_I = GameObject.Find("Player").GetComponent<Player_Item>();
        //이 텍스트를 넣어줄 패널 필요
    }

    // Update is called once per frame
    void Update()
    {
        get_Player_State_Text();
    }

    public void get_Player_State_Text()
    {
        HP.text = P_S.Get_P_State(1) + " / " + P_S.Get_P_State(0) + " (" + P_S.Get_P_Base_State(0) + " + " + (P_S.Get_P_State(0) - P_S.Get_P_Base_State(0)) + ")";
        STR.text = P_S.Get_P_State(2) + " (" + P_S.Get_P_Base_State(2) + " + " + (P_S.Get_P_State(2) - P_S.Get_P_Base_State(2)) + ")";
        DEF.text = P_S.Get_P_State(3) + " (" + P_S.Get_P_Base_State(3) + " + " + (P_S.Get_P_State(3) - P_S.Get_P_Base_State(3)) + ")";
        AGI.text = P_S.Get_P_State(4) + " (" + P_S.Get_P_Base_State(4) + " + " + (P_S.Get_P_State(4) - P_S.Get_P_Base_State(4)) + ")";
        LUK.text = P_S.Get_P_State(5) + " (" + P_S.Get_P_Base_State(5) + " + " + (P_S.Get_P_State(5) - P_S.Get_P_Base_State(5)) + ")";
        Money.text = P_S.Get_P_State(6).ToString();

        if (P_I.Weapon)
        {
            Weapon.text = P_I.Get_Player_Item(0) + " +" + P_I.Weapon.GetComponent<Item_stats>().reinforce_add.ToString();
        }
        else
        {
            Weapon.text = "NOPE";
        }

        if (P_I.Armor)
        {
            Armor.text = P_I.Get_Player_Item(1) + " +" + P_I.Armor.GetComponent<Item_stats>().reinforce_add.ToString();
        }
        else
        {
            Armor.text = "NOPE";
        }

        if (P_I.Hat)
        {
            Hat.text = P_I.Get_Player_Item(2) + " +" + P_I.Hat.GetComponent<Item_stats>().reinforce_add.ToString();
        }
        else
        {
            Hat.text = "NOPE";
        }

        if (P_I.Ring)
        {
            Ring.text = P_I.Get_Player_Item(3) + " +" + P_I.Ring.GetComponent<Item_stats>().reinforce_add.ToString();
        }
        else
        {
            Ring.text = "NOPE";
        }
    }
}
