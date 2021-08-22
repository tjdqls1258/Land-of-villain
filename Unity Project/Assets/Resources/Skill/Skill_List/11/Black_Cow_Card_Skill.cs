using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Black_Cow_Card_Skill : MonoBehaviour, Skill
{
    public GameObject Skill_Bullte;
    GameObject Player;
    //액티브 스킬
    public void Skill_Action()
    {
        Player = GameObject.Find("Player");

        if (Player.GetComponent<Player_Stat>().Get_P_State(6) >= 100)
        {
            Player.GetComponent<Player_Stat>().Set_P_State(6, Player.GetComponent<Player_Stat>().Get_P_State(6) - 100);
            GameObject Skill01 = Instantiate(Skill_Bullte, Player.transform.position, Quaternion.identity);
            Skill01.GetComponent<Bullte_Setting>().Setting(Player.GetComponent<Player_Stat>().Get_P_State(2));
            Invoke("SkillMore", 0.3f);
        }
    }
    void SkillMore()
    {
        GameObject Skill02 = Instantiate(Skill_Bullte, Player.transform.position, Quaternion.identity);
        Skill02.GetComponent<Bullte_Setting>().Setting(Player.GetComponent<Player_Stat>().Get_P_State(2));
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
