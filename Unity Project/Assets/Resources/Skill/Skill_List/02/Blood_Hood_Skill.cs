using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood_Hood_Skill : MonoBehaviour, Skill
{
    public float 지속시간;
    int reset_stat;
    public GameObject Buffe_Image;
    private bool Is_Action = false;

    GameObject Buffe_;

    public void Skill_Action()
    {
        GameObject Player = GameObject.Find("Player");
        if (Player.GetComponent<Player_Item>().Ring != null)
        {
            if (Player.GetComponent<Player_Item>().Ring.GetComponent<Item_stats>().Get_Item_Name() == "Blood_Ring")
            {
                지속시간 = 4;
            }
        }
        GameObject Buffe_Panel = Player.transform.Find("Play_UI").transform.
        Find("BuffPanel").gameObject;
        int Delete_Hp =(int)(Player.GetComponent<Player_Stat>().Get_P_Base_State(0) * 0.05f);
        
        if((Player.GetComponent<Player_Stat>().Get_P_Base_State(1) - Delete_Hp) < 0 )
        {
            return;
        }
        Buffe_ = Instantiate(Buffe_Image, Vector3.zero, Quaternion.identity);
        Buffe_.transform.parent = Buffe_Panel.transform;
        Is_Action = true;
        Player.GetComponent<Player_Stat>().Set_P_State(1, Player.GetComponent<Player_Stat>().Get_P_Base_State(1) - Delete_Hp);
        reset_stat = (int)(Player.GetComponent<Player_Stat>().Get_P_State(4) * 0.5f);
        Debug.Log("모자 스킬발사 히히");
        Player.GetComponent<Player_Stat>().Set_P_State(4, Player.GetComponent<Player_Stat>().Get_P_State(4) + reset_stat);
        Invoke("Buffe", 지속시간);

    }
    public void Stop_Passive()
    {

    }
    void Buffe()
    {
        GameObject Player = GameObject.Find("Player");
        Player.GetComponent<Player_Stat>().Set_P_State(4, Player.GetComponent<Player_Stat>().Get_P_State(4) - reset_stat);
        Is_Action = false;
        Destroy(Buffe_);
        Debug.Log("모자 스킬종료 희희");
    }
}
