using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danger : MonoBehaviour
{
    GameObject Skills;
    Vector3 this_transform;
    public void Patan_Ative(GameObject Skills)
    {
        GameObject Player = GameObject.Find("Player");
        GameObject this_gameObject = Instantiate(gameObject, Player.transform.position, Quaternion.identity);
        this_transform = this_gameObject.transform.position;
        this.Skills = Skills;
        Invoke("Do_Skill",0.25f);
    }
    void Do_Skill()
    {
        Instantiate(Skills, this_transform, Quaternion.identity);
    }
}
