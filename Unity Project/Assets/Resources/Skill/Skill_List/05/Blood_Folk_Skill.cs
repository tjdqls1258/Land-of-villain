using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood_Folk_Skill : MonoBehaviour, Skill
{
    public GameObject Bullte;
    public void Stop_Passive() { }
    public void Passive() { }
    public void Skill_Action()
    {
        GameObject Player = GameObject.Find("Player");

        float angle = Mathf.Atan2(Joystick.inputDirection.y
            , Joystick.inputDirection.x) * Mathf.Rad2Deg; //플레이어가 바라보는 각도       

        GameObject Skill = Instantiate(Bullte,
                Player.transform.position, Quaternion.AngleAxis(angle - 90, Vector3.forward));
        Skill.GetComponent<Set_Damage>().SetDamage(Player.GetComponent<Player_Stat>().Get_P_State(2));
       
        Debug.Log("무기 스킬발사 히히");
    }
}
