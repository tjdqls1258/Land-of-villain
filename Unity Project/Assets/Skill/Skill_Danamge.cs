using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Danamge : MonoBehaviour
{
    public int Skill_Damage;
    // Start is called before the first frame update
    float time;
    public float 지속시간;
    void Start()
    {
        transform.position += transform.up * 0.5f; 
        time = 0;
        GameObject Players = GameObject.Find("Player");
        Skill_Damage += Players.GetComponent<Player_Stat>().Get_P_State(2);
    }
    public int Damage()
    {
        return Skill_Damage;
    }

    public void Update()
    {
        time += Time.deltaTime;
        if(time >= 지속시간)
        {
            Destroy(gameObject);
        }
    }
}
