using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Danamge : MonoBehaviour
{
    public int Skill_Damage;
    // Start is called before the first frame update
    void Start()
    {
        GameObject Players = GameObject.Find("Player");
        Skill_Damage += Players.GetComponent<Player_Stat>().Get_P_State(2);
    }
    public int Damage()
    {
        return Skill_Damage;
    }

}
