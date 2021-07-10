using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_stats_01 : MonoBehaviour
{
    public int[] Item_stat;
    public string Item_Name;//아이템의 이름
    public int Item_Kind;//아이템의 종류 무기=0,갑옷=1,투구=2,악세서리=3
    // 0 = 종류
    // 1 = 체력
    // 2 = 힘
    // 3 = 방어력
    // 4 = 민첩
    // 5 = 운
    // 그 이상 부가 스텟
    public string skill_number;
    //public Skill skill;
    public float CoolTime;
    public void Awake()
    {
        this.transform.parent = null; //아이템 상속 해제
    }
    public void Skill_Set()
    {
       // this.skill = (Skill)Resources.Load("Skill/Skill_List/" + skill_number, typeof(Skill));
    }
    //아이템의 이름을 반환하는 함수
    public string Get_Item_Name()
    { return Item_Name; }
    //아이템의 종류를 반환하는 함수
    public int Get_Item_Kind()
    { return Item_Kind; }
}
