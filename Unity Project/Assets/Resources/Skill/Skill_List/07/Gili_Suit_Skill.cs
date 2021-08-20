using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gili_Suit_Skill : MonoBehaviour ,Skill
{
    public float 지속시간;
    int reset_stat;
    public GameObject Buffe_Image;
    private bool Is_Action = false;

    GameObject Buffe_;
    //치명 확률 상승
    public void Skill_Action()
    {
        GameObject Player = GameObject.Find("Player");

        GameObject Buffe_Panel = Player.transform.Find("Play_UI").transform.
            Find("BuffPanel").gameObject;
        Buffe_ = Instantiate(Buffe_Image, Vector3.zero, Quaternion.identity);
        Buffe_.transform.parent = Buffe_Panel.transform;
        Is_Action = true;
        reset_stat = (int)(Player.GetComponent<Player_Stat>().Get_P_State(5) * 0.5f);
        Debug.Log("모자 스킬발사 히히");
        Player.GetComponent<Player_Stat>().Set_P_State(5, Player.GetComponent<Player_Stat>().Get_P_State(5) + reset_stat);
        Invoke("Buffe", 지속시간);
    }
    void Buffe()
    {
        GameObject Player = GameObject.Find("Player");
        Player.GetComponent<Player_Stat>().Set_P_State(5, Player.GetComponent<Player_Stat>().Get_P_State(5) - reset_stat);
        Is_Action = false;
        Destroy(Buffe_);
        Debug.Log("모자 스킬종료 희희");
    }
    public void Passive()
    {

    }
    //중지시키는 함수
    public void Stop_Passive()
    {
    }
}
