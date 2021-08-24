using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_stats : MonoBehaviour
{

    public string Item_Name;//아이템의 이름
    public int Item_Kind; //아이템 종류
    public int tear;//아이템 등급  0 , 1 , 2 =  N ,  R ,  E
    public int[] Item_stat;
    // 0 = 강화정도
    // 1 = 체력
    // 2 = 힘
    // 3 = 방어력
    // 4 = 민첩
    // 5 = 운
    // 그 이상 부가 스텟
    public bool meeleatk;//근접공격여부를 정하는 변수, 근접무기에 true선언하면됨

    public string skill_number; // 스킬 이름
    public Skill skill;  //보유 스킬
    public float CoolTime;//스킬 쿨타임
    public string Item_Information;//아이템 설명.
    GameObject player_s;

    public int reinforce_add; //강화 수치
    public string item_skill_name;

    public float ATK_Speed;

    public GameObject Bullte;
    public void Awake()
    {
        this.transform.parent = null; //아이템 상속 해제
    }
    //스킬을 세팅해주는 함수 (아이템 교체될때마다 해줘야함)
    public void Skill_Set()
    {
        this.skill = (Skill)Resources.Load("Skill/Skill_List/" + skill_number, typeof(Skill));
    }
    public void Add_Stat()
    {
        player_s = GameObject.Find("Player");
        player_s.GetComponent<Player_Stat>().Add_P_State(0, Item_stat[1]);
        for (int i = 2; i < Item_stat.Length; i++)
        {
            player_s.GetComponent<Player_Stat>().Add_P_State(i, Item_stat[i]);
        }
        player_s.GetComponent<Player_Stat>().Reset_Speed();
    }
    public void Delete_Stat()
    {
        player_s = GameObject.Find("Player");
        player_s.GetComponent<Player_Stat>().Miner_P_State(0, Item_stat[1]);
        for (int i = 2; i < Item_stat.Length; i++)
        {
            player_s.GetComponent<Player_Stat>().Miner_P_State(i, Item_stat[i]);
        }
        player_s.GetComponent<Player_Stat>().Reset_Speed();
    }
    //아이템 강화에 사용되는 함수
    public void reinforce()
    {
        reinforce_add++;
        Delete_Stat();
        for (int i = 0; i< Item_stat.Length;i++)
        {
            Item_stat[i] += (int)Mathf.Ceil((Item_stat[i] * 0.1f));
        }
        Add_Stat();
    }
    //아이템의 이름을 반환하는 함수
    public string Get_Item_Name()
    { return Item_Name; }
    //아이템의 종류를 반환하는 함수
    public int Get_Item_Kind()
    { return Item_Kind; }

    public string Get_Item_Skill_Name()
    { return item_skill_name; }

    public string Get_Item_Information()
    {
        return Item_Information;
    }
}
