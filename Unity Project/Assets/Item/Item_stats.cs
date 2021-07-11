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


    public string skill_number; // 스킬 이름
    public Skill skill;  //보유 스킬
    public float CoolTime;//스킬 쿨타임

    public int reinforce_add; //강화 수치
    public void Awake()
    {
        this.transform.parent = null; //아이템 상속 해제
    }
    //스킬을 세팅해주는 함수 (아이템 교체될때마다 해줘야함)
    public void Skill_Set()
    {
        this.skill = (Skill)Resources.Load("Skill/Skill_List/" + skill_number, typeof(Skill));
    }
    //아이템 강화에 사용되는 함수
    public void reinforce()
    {
        for(int i = 0; i< Item_stat.Length; i++) //임의로 모든 스텟 상승
        {
            Item_stat[i]+= reinforce_add;
        }
    }
    //아이템의 이름을 반환하는 함수
    public string Get_Item_Name()
    { return Item_Name; }
    //아이템의 종류를 반환하는 함수
    public int Get_Item_Kind()
    { return Item_Kind; }
}
