using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 효자손_Skill : MonoBehaviour, Skill
{
    GameObject Player;
    int count;

    public GameObject Buffe_Image;
    GameObject Buffe_;

    //액티브 스킬
    public void Skill_Action()
    {

        GameObject Buffe_Panel = Player.transform.Find("Play_UI").transform.
           Find("BuffPanel").gameObject;
        Buffe_ = Instantiate(Buffe_Image, Vector3.zero, Quaternion.identity);
        Buffe_.transform.parent = Buffe_Panel.transform;

        Player = GameObject.Find("Player");
        count = 0;
        InvokeRepeating("Hp_Add",1f, 1f);

    }
    void Hp_Add()
    {
        int N_HP = Player.GetComponent<Player_Stat>().Get_P_State(1); //현재 HP
        if (N_HP + 10 > Player.GetComponent<Player_Stat>().Get_P_State(0))//현재 HP+10 > 최대 HP
        {
            Player.GetComponent<Player_Stat>().Set_P_State(
                1, Player.GetComponent<Player_Stat>().Get_P_State(0));
        }
        else
        {
            Player.GetComponent<Player_Stat>().Set_P_State(1, N_HP + 10);
        }
        count++;
        if(count >= 5)
        {
            Destroy(Buffe_);
            CancelInvoke("Hp_Add");
        }
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
