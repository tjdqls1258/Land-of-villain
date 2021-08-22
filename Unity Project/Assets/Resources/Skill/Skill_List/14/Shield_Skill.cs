using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield_Skill : MonoBehaviour, Skill
{
    public GameObject Shiled;
    GameObject prefap;
    public void Skill_Action()
    {
        
    }

    public void Passive()
    {
        GameObject Player =  GameObject.Find("Player");
        prefap = Instantiate(Shiled, Player.transform.position, Quaternion.identity);
    }
    //중지시키는 함수
    public void Stop_Passive()
    {
        Destroy(prefap);
    }
}
