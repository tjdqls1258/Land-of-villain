using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja_Scroll_Skill : MonoBehaviour, Skill
{
    public float 지속시간;

    public GameObject Buffe_Image;
    GameObject Buffe_;

    GameObject Player;
    //액티브 스킬
    public void Skill_Action()
    {
        Player = GameObject.Find("Player");
        GameObject Buffe_Panel = Player.transform.Find("Play_UI").transform.
            Find("BuffPanel").gameObject;
        Buffe_ = Instantiate(Buffe_Image, Vector3.zero, Quaternion.identity);
        Buffe_.transform.parent = Buffe_Panel.transform;
        Debug.Log("아머 스킬발사 히히");
        Player.GetComponent<BoxCollider2D>().enabled = false;
        Invoke("Buffe", 지속시간);
    }
    void Buffe()
    {
        Player.GetComponent<BoxCollider2D>().enabled = true;
        Destroy(Buffe_);
        Debug.Log("아머 스킬종료 희희");
    }
    //패시브(InvokeRepeating을 사용해서 함수 반복 해야함)
    public void Passive()
    {

    }
    //중지시키는 함수
    public void Stop_Passive()
    {
    }
}
