using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_01_Emp : MonoBehaviour
{
    GameObject Players;
    public int Skill_Damage;
    public float cool_Time;
    void Awake()
    {
        Players = GameObject.Find("Player");
        Skill_Damage += Players.GetComponent<Player_Stat>().Get_P_State(2);
        StartCoroutine("Die");
    }

    IEnumerator Die()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        Destroy(gameObject);
    }
    public int Damage()
    {
        return Skill_Damage;
    }
}
