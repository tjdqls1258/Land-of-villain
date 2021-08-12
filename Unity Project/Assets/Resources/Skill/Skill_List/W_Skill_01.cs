using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W_Skill_01 : MonoBehaviour, Skill 
{
    public void Stop_Passive() { }
    public void Passive() { }
    public void Skill_Action()
    {
        GameObject Player = GameObject.Find("Player");

        float angle = Mathf.Atan2(Joystick.inputDirection.y
            , Joystick.inputDirection.x) * Mathf.Rad2Deg; //플레이어가 바라보는 각도       

        GameObject Skill = Instantiate((GameObject)Resources.Load(("Skill/P_Skill_01"), typeof(GameObject)),
                Player.transform.position, Quaternion.AngleAxis(angle - 90, Vector3.forward));
        Skill.transform.position += Skill.transform.up * 0.5f;
        Debug.Log("무기 스킬발사 히히");
    }
}
