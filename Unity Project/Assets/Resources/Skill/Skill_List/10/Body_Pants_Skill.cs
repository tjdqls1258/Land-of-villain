using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body_Pants_Skill : MonoBehaviour, Skill
{
    GameObject Player;

    public float 지속시간;
    int reset_stat;

    private bool Is_Action = false;

    public GameObject Buffe_Image;
    GameObject Buffe_;
    //액티브 스킬
    public void Skill_Action()
    {
        Player = GameObject.Find("Player");
        GameObject Buffe_Panel = Player.transform.Find("Play_UI").transform.
            Find("BuffPanel").gameObject;
        Buffe_ = Instantiate(Buffe_Image, Vector3.zero, Quaternion.identity);
        Buffe_.transform.parent = Buffe_Panel.transform;
        reset_stat = (int)(Player.GetComponent<Player_Stat>().Get_P_State(4) * 0.2f);
        Is_Action = true;
        Player.GetComponent<Player_Stat>().Set_P_State(4,
            (int)(Player.GetComponent<Player_Stat>().Get_P_State(4) + reset_stat));
        Invoke("Buffe", 지속시간);
    }
    void Buffe()
    {
        GameObject Player = GameObject.Find("Player");
        Player.GetComponent<Player_Stat>().Set_P_State(4,
            (int)(Player.GetComponent<Player_Stat>().Get_P_State(4) - reset_stat));
        Destroy(Buffe_);
        Debug.Log("휴");
        Is_Action = false;
    }
    //패시브(InvokeRepeating을 사용해서 함수 반복 해야함)
    public void Passive()
    {
    }
    //중지시키는 함수
    public void Stop_Passive()
    {
    }
}
