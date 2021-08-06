using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_Skill_01 : MonoBehaviour, Skill
{
    public int Healing;
    GameObject Player;
    private bool Is_Action = false;

    public GameObject Buffe_Image;
    GameObject Buffe_;

    Animator animator;

    public void Skill_Action()
    {
        Player = GameObject.Find("Player");
        InvokeRepeating("Passive", 0, 1); //0초후에 Passive를 1초간격으로 반복 
        Is_Action = true;

        GameObject Buffe_Panel = Player.transform.Find("Play_UI").transform.
           Find("BuffPanel").gameObject;
        if(Buffe_ != null)
        {
            Destroy(Buffe_);
        }
        Buffe_ = Instantiate(Buffe_Image, Vector3.zero, Quaternion.identity);
        Buffe_.transform.parent = Buffe_Panel.transform;
        // 장비 해제시 중지 시켜줘야함.
        animator = Player.GetComponent<Animator>();
    }

    public void Passive()
    {
        Debug.Log("패시브 발사 히히");
        animator.SetBool("Heal", true);
        int N_HP = Player.GetComponent<Player_Stat>().Get_P_State(1);
        if (N_HP + Healing > Player.GetComponent<Player_Stat>().Get_P_State(0))
        {
            Player.GetComponent<Player_Stat>().Set_P_State(
                1, Player.GetComponent<Player_Stat>().Get_P_State(0));
        }
        else
        {
            Player.GetComponent<Player_Stat>().Set_P_State(1, N_HP + Healing);
        }
        if(Player != null)
        {
            CancelInvoke("Stop_Passive");
        }
    }
    //중지시키는 함수
    public void Stop_Passive()
    {
        if (Is_Action == true)
        {
            CancelInvoke("Passive");
        }
        Destroy(Buffe_);
        Is_Action = false;
        animator.SetBool("Heal", false);
    }
}
