using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gas_Mask_Skill : MonoBehaviour,Skill
{
    public GameObject Buffe_Image;
    GameObject Buffe_;
    GameObject Player;
    float reset;
    public void Skill_Action()
    {

    }
    public void Stop_Passive()
    {
        Player.GetComponent<Player_Status>().Debuff_DEF = reset;
        Destroy(Buffe_);
    }
    public void Passive()
    {
        GameObject Buffe_Panel = Player.transform.Find("Play_UI").transform.
           Find("BuffPanel").gameObject;
        if (Buffe_ != null)
        {
            Destroy(Buffe_);
        }
        Buffe_ = Instantiate(Buffe_Image, Vector3.zero, Quaternion.identity);
        Buffe_.transform.parent = Buffe_Panel.transform;

        Player = GameObject.Find("Player");
        reset = Player.GetComponent<Player_Status>().Debuff_DEF;

        Player.GetComponent<Player_Status>().Debuff_DEF = 30.0f;

    }
}
