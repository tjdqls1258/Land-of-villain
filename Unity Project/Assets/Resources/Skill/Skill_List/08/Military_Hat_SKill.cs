using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Military_Hat_SKill : MonoBehaviour, Skill
{
    public GameObject Shiled;
    GameObject prefap;
    public void Skill_Action()
    {
        prefap = Instantiate(Shiled, transform.position, Quaternion.identity);
        Invoke("Destory_this", 5.0f);
    }

    void Destory_this()
    {
        Destroy(prefap);
    }
    public void Passive()
    {

    }
    //중지시키는 함수
    public void Stop_Passive()
    {
    }
}
