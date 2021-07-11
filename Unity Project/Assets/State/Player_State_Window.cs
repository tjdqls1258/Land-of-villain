using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player_State_Window : MonoBehaviour
{   //이 코드는 캔버스나, Player_State_Window_UI에 직접 넣는게 아닌 하나의 통합 UI에 넣는 코드임을 고려해서 작성함
    private Text P_S_Text;
    Player_Stat P_S;
    Player_Item P_I;

    void Start()
    {
        //P_S_Text=GameObject.Find("Player_State_Window_UI").GetComponent<Text>();
        P_S_Text = GameObject.Find("Player_State_UI_text").GetComponent<Text>();
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
        P_S_Text.text = "<Max HP / HP> : " + P_S.Get_P_State(0) + " / " + P_S.Get_P_State(1) + "\n"
        + "<STR> : " + P_S.Get_P_State(2) + "\n"
        + "<DEF> : " + P_S.Get_P_State(3) + "\n"
        + "<AGI> : " + P_S.Get_P_State(4) + "\n"
        + "<LUC> : " + P_S.Get_P_State(5) + "\n"
        + "<Money> : " + P_S.Get_P_State(6) + "\n"
        + "\n" + "\n"
        + "equipment" + "\n"
        + "weapon : " + P_I.Get_Player_Item(0) + "\n"
        + "armor : " + P_I.Get_Player_Item(1) + "\n"
        + "hat : " + P_I.Get_Player_Item(2) + "\n"
        + "ring : " + P_I.Get_Player_Item(3) + "\n"; 
    }
}
