using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow_Save_Skill : MonoBehaviour
{
    public float 지속시간;
    int reset_stat;

    private bool Is_Action = false;

    public GameObject Buffe_Image;
    GameObject Buffe_;

    public void Skill_Action()
    {
        GameObject Player = GameObject.Find("Player");
        GameObject Buffe_Panel = Player.transform.Find("Play_UI").transform.
            Find("BuffPanel").gameObject;
        reset_stat = 1;
        Player.GetComponent<Player_Stat>().Set_P_State(7,
            (int)(Player.GetComponent<Player_Stat>().Get_P_State(7) + reset_stat));
        Invoke("Buffe", 지속시간);
    }

    public void Passive()
    {

    }
    //중지시키는 함수
    public void Stop_Passive()
    {
    }
    void Buffe()
    {
        GameObject Player = GameObject.Find("Player");
        Player.GetComponent<Player_Stat>().Set_P_State(7,
            (int)(Player.GetComponent<Player_Stat>().Get_P_State(7) - reset_stat));
        Destroy(Buffe_);
        Is_Action = false;
    }
}
