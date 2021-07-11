using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W_Skill_01 : MonoBehaviour, Skill 
{
    public void Stop_Passive() { }
    public void Skill_Action()
    {
        GameObject Player = GameObject.Find("Player");
        Instantiate((GameObject)Resources.Load(("Skill/P_Skill_01"),typeof(GameObject)),
            Player.transform.position, Player.transform.rotation);
        Debug.Log("무기 스킬발사 히히");
    }
}
