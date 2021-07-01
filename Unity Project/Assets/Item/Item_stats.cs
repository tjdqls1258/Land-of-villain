using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_stats : MonoBehaviour
{
    public int[] Item_stat = { };
    // 0 = 종류
    // 1 = 공격력
    // 2 = 방어력
    // 그 이상 부가 스텟
    public string skill_number;
    public Skill skill;
    public float CoolTime;
    public void Skill_Set()
    {
        skill = (Skill)Resources.Load("Skill/Skill list/"+ skill_number, typeof(Skill));
    }
}
