using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuRuTan_Skill : MonoBehaviour, Skill
{
    public GameObject SuRuTans;
    public void Stop_Passive() { }
    public void Passive() { }
    public void Skill_Action()
    {
        GameObject Player = GameObject.Find("Player");

        float angle = Mathf.Atan2(Joystick.inputDirection.y
            , Joystick.inputDirection.x) * Mathf.Rad2Deg; //플레이어가 바라보는 각도  

        GameObject SuRuTan1 = SuRuTans;
        SuRuTan1.GetComponent<SuRuTan>().Set_Distance(0.5f);
        GameObject SuRuTan1_1 = Instantiate(SuRuTan1, Player.transform.position, Quaternion.AngleAxis(angle - 90, Vector3.forward));
        SuRuTan1_1.GetComponent<Set_Damage>().SetDamage(Player.GetComponent<Player_Stat>().Get_P_State(2));
       
        
        GameObject SuRuTan2 = SuRuTans;
        SuRuTan2.GetComponent<SuRuTan>().Set_Distance(1f);
        GameObject SuRuTan2_1 = Instantiate(SuRuTan2, Player.transform.position, Quaternion.AngleAxis(angle - 90, Vector3.forward));
        SuRuTan2_1.GetComponent<Set_Damage>().SetDamage(Player.GetComponent<Player_Stat>().Get_P_State(2));
        

        GameObject SuRuTan3 = SuRuTans;
        SuRuTan3.GetComponent<SuRuTan>().Set_Distance(1.5f);
        GameObject SuRuTan3_1 = Instantiate(SuRuTan3, Player.transform.position, Quaternion.AngleAxis(angle - 90, Vector3.forward));
        SuRuTan3_1.GetComponent<Set_Damage>().SetDamage(Player.GetComponent<Player_Stat>().Get_P_State(2));
        
       
        
        
        
        Debug.Log("수류탄 스킬발사 히히");
    }
}
