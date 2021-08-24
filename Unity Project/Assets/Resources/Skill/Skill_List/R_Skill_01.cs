using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_Skill_01 : MonoBehaviour, Skill
{
    public int Healing;
    GameObject Player;

    public GameObject Buffe_Image;
    GameObject Buffe_;

    Animator animator;

    public void Skill_Action()
    {
        
    }


    public void Passive()
    {
        Player = GameObject.Find("Player"); 

        GameObject Buffe_Panel = Player.transform.Find("Play_UI").transform.
           Find("BuffPanel").gameObject;
        if (Buffe_ != null)
        {
            Destroy(Buffe_);
        }
        Buffe_ = Instantiate(Buffe_Image, Vector3.zero, Quaternion.identity);
        Buffe_.transform.parent = Buffe_Panel.transform;
        // 장비 해제시 중지 시켜줘야함.
        animator = Player.GetComponent<Animator>();

        Debug.Log("패시브 발사 히히");
        animator.SetBool("Heal", true);
        InvokeRepeating("Helling", 0f, 5f);
    }
    void Helling()
    {
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
    }
    //중지시키는 함수
    public void Stop_Passive()
    {
        Destroy(Buffe_);
        CancelInvoke("Passive");

       
    }
}
