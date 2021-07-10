using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_stats : MonoBehaviour
{
    public int[] Item_stat;
    // 0 = 종류
    // 1 = 체력
    // 2 = 힘
    // 3 = 방어력
    // 4 = 민첩
    // 5 = 운
    // 그 이상 부가 스텟

    public string item_name;
    private int 강화;

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
    public int 강화정도()
    {
        return 강화;
    }
    public void 강화시도(int i)
    {
        강화 += i;
    }
}
