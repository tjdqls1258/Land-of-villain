using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic_Hat_Skill : MonoBehaviour, Skill
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
        Buffe_ = Instantiate(Buffe_Image, Vector3.zero, Quaternion.identity);
        Buffe_.transform.parent = Buffe_Panel.transform;

        reset_stat = 5;
        Player.GetComponent<Player_Stat>().Set_P_State(2,
            (int)(Player.GetComponent<Player_Stat>().Get_P_State(2) + reset_stat));
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
        Player.GetComponent<Player_Stat>().Set_P_State(2,
            (int)(Player.GetComponent<Player_Stat>().Get_P_State(2) - reset_stat));
        Destroy(Buffe_);
        Is_Action = false;
    }
}
