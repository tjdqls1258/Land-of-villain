using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Stafe_Skill_Bullte : MonoBehaviour
{
    GameObject Player;
    private void Awake()
    {
        Player = GameObject.Find("Player");
        
        Invoke("Set_false",3f);
    }
    void Update()
    {
        float angle = Mathf.Atan2(Joystick.inputDirection.y
            , Joystick.inputDirection.x) * Mathf.Rad2Deg;
        gameObject.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        gameObject.transform.position = Player.transform.position;
    }
    void Set_false()
    {
        Destroy(gameObject);
    }
}
