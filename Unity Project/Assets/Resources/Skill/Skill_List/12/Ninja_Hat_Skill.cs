using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja_Hat_Skill : MonoBehaviour, Skill
{
    public float 지속시간;
    int reset_stat;
    int reset_stat1;
    public GameObject Buffe_Image;

    GameObject Buffe_;
    //액티브 스킬
    public void Skill_Action()
    {
        GameObject Player = GameObject.Find("Player");

        GameObject Buffe_Panel = Player.transform.Find("Play_UI").transform.
            Find("BuffPanel").gameObject;
        Buffe_ = Instantiate(Buffe_Image, Vector3.zero, Quaternion.identity);
        Buffe_.transform.parent = Buffe_Panel.transform;

        reset_stat = (int)(Player.GetComponent<Player_Stat>().Get_P_State(4) * 0.5f);
        reset_stat1 = (int)(Player.GetComponent<Player_Stat>().Get_P_State(7) + 0.5f);
        Debug.Log("모자 스킬발사 히히");
        Player.GetComponent<Player_Stat>().Set_P_State(4, Player.GetComponent<Player_Stat>().Get_P_State(4) + reset_stat);
        Player.GetComponent<Player_Stat>().Set_P_State(7, Player.GetComponent<Player_Stat>().Get_P_State(7) + reset_stat1);
        Invoke("Buffe", 지속시간);
    }
    void Buffe()
    {
        GameObject Player = GameObject.Find("Player");
        Player.GetComponent<Player_Stat>().Set_P_State(4, Player.GetComponent<Player_Stat>().Get_P_State(4) - reset_stat);
        Player.GetComponent<Player_Stat>().Set_P_State(7, Player.GetComponent<Player_Stat>().Get_P_State(7) - reset_stat1);

        Destroy(Buffe_);
        Debug.Log("모자 스킬종료 희희");
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
