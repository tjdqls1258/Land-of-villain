using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood_A_Skill : MonoBehaviour, Skill
{
    public float 지속시간;
    int reset_stat;

    private bool Is_Action = false;

    public GameObject Buffe_Image;
    GameObject Buffe_;
    public void Passive()
    {

    }
    public void Skill_Action()
    {

        GameObject Player = GameObject.Find("Player");
        if (Player.GetComponent<Player_Item>().Ring != null)
        {
            if (Player.GetComponent<Player_Item>().Ring.GetComponent<Item_stats>().Get_Item_Name() == "Blood Ring")
            {
                지속시간 = 4;
            }
        }

        int Delete_Hp = (int)(Player.GetComponent<Player_Stat>().Get_P_State(0) * 0.1f);

        if ((Player.GetComponent<Player_Stat>().Get_P_State(1) - Delete_Hp) < 0)
        {
            return;
        }
        Player.GetComponent<Player_Stat>().Set_P_State(1, Player.GetComponent<Player_Stat>().Get_P_State(1) - Delete_Hp);
        GameObject Buffe_Panel = Player.transform.Find("Play_UI").transform.
            Find("BuffPanel").gameObject;
        Buffe_ = Instantiate(Buffe_Image, Vector3.zero, Quaternion.identity);
        Buffe_.transform.parent = Buffe_Panel.transform;
        Debug.Log("아머 스킬발사 히히");
        Is_Action = true;
        Player.GetComponent<BoxCollider2D>().enabled = false;
        Invoke("Buffe", 지속시간);

    }
    public void Stop_Passive()
    {

    }
    void Buffe()
    {
        
        GameObject Player = GameObject.Find("Player");
        Player.GetComponent<BoxCollider2D>().enabled = true;
        Destroy(Buffe_);
        Debug.Log("아머 스킬종료 희희");
        Is_Action = false;
    }
}
