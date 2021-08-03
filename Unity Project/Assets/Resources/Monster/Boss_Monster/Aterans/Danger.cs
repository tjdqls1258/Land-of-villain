using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danger : MonoBehaviour
{
    GameObject Skills;
    Vector3 this_transform;
    int Damages;

    public void Patan_Ative(GameObject Skills, int Damage, Vector3 Target)
    {
        this_transform = Target;
        this.Skills = Skills;
        Damages = Damage;
        Invoke("Do_Skill",0.2f);
    }

    void Do_Skill()
    {
        GameObject Do_Skill =  Instantiate(Skills, this_transform, Quaternion.identity);
        Do_Skill.GetComponent<Skill_damage>().Set_Damage(Damages);
    }
}
