using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class A_Skill_01 : MonoBehaviour, Skill
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
        reset_stat = (int)(Player.GetComponent<Player_Stat>().Get_P_State(3) * 0.5f);
        Debug.Log("아머 스킬발사 히히");
        Is_Action = true;
        Player.GetComponent<Player_Stat>().Set_P_State(3, 
            (int)(Player.GetComponent<Player_Stat>().Get_P_State(3) + reset_stat));
        Invoke("Buffe", 지속시간);

    }
    public void Stop_Passive() 
    {
        
    }
    public void Passive()
    {

    }
    void Buffe()
    {
        GameObject Player = GameObject.Find("Player");
        Player.GetComponent<Player_Stat>().Set_P_State(3,
            (int)(Player.GetComponent<Player_Stat>().Get_P_State(3) - reset_stat));
        Destroy(Buffe_);
        Debug.Log("아머 스킬종료 희희");
        Is_Action = false;
    }
}

