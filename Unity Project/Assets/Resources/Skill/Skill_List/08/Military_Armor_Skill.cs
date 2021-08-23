using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Military_Armor_Skill : MonoBehaviour, Skill
{
    GameObject Player;
    float Dash_First;

    public GameObject Buffe_Image;
    GameObject Buffe_;
    public void Skill_Action()
    {

    }

    public void Passive()
    {
        Player = GameObject.Find("Player");
        GameObject Buffe_Panel = Player.transform.Find("Play_UI").transform.
            Find("BuffPanel").gameObject;
        Buffe_ = Instantiate(Buffe_Image, Vector3.zero, Quaternion.identity);
        Buffe_.transform.parent = Buffe_Panel.transform;

        Dash_First = Player.GetComponent<SkillCooldown>().Dash_Cool;
        Player.GetComponent<SkillCooldown>().Dash_Cool -= Player.GetComponent<SkillCooldown>().Dash_Cool * 0.2f;
    }
    //중지시키는 함수
    public void Stop_Passive()
    {
        if (Player != null)
        {
            Player.GetComponent<SkillCooldown>().Dash_Cool = Dash_First;
            Destroy(Buffe_);
        }
    }
}
