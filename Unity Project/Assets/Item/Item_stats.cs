using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_stats : MonoBehaviour
{
    public int[] Item_stat;
    public string Item_Name;//아이템의 이름
    public int Item_Kind;
    // 0 = 강화정도
    // 1 = 체력
    // 2 = 힘
    // 3 = 방어력
    // 4 = 민첩
    // 5 = 운
    // 그 이상 부가 스텟
    public string skill_number;
    public Skill skill;
    public float CoolTime;
    public void Awake()
    {
        this.transform.parent = null; //아이템 상속 해제
    }
    public void Skill_Set()
    {
        this.skill = (Skill)Resources.Load("Skill/Skill_List/" + skill_number, typeof(Skill));
    }
    public void reinforce()
    {
        for(int i = 0; i< Item_stat.Length; i++)
        {
            Item_stat[i]++;
        }
    }
    public string Get_Item_Name()
    { return Item_Name; }
    //아이템의 종류를 반환하는 함수
    public int Get_Item_Kind()
    { return Item_Kind; }
}
