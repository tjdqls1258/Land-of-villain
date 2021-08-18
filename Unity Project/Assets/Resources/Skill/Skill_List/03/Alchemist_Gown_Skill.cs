using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alchemist_Gown_Skill : MonoBehaviour, Skill
{
    public float 지속시간;
    int reset_stat;

    public int Delete_Time;
    private bool Is_Action = false;

    public GameObject Buffe_Image;
    GameObject Buffe_;

    public void Skill_Action()
    {
        GameObject Player = GameObject.Find("Player");

        Player.GetComponent<SkillCooldown>().Wepon_CoolTime_Delet(Delete_Time);
        Player.GetComponent<SkillCooldown>().Amor_CoolTime_Delet(Delete_Time);
        Player.GetComponent<SkillCooldown>().Ring_CoolTime_Delet(Delete_Time);

        Debug.Log("아머 스킬발사 히히");
        Is_Action = true;

        Invoke("Buffe", 지속시간);

    }
    public void Stop_Passive()
    {

    }
    public void Passive()
    {

    }
    void Buffe()
    {
        GameObject Player = GameObject.Find("Player");

        Debug.Log("아머 스킬종료 희희");
        Is_Action = false;
    }
}
