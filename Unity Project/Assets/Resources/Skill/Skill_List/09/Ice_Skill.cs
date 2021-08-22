using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice_Skill : MonoBehaviour
{
    GameObject Player;
    public float rotate_Speed;
    // Start is called before the first frame update
    void Awake()
    {
        Player = GameObject.Find("Player");
        Player.GetComponent<SkillCooldown>().atkdelay = true;
        Invoke("Set_false", 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(new Vector3(0, 0, rotate_Speed * Time.deltaTime));
        gameObject.transform.position = Player.transform.position;
    }
    void Set_false()
    {
        Player.GetComponent<SkillCooldown>().atkdelay = false;
    }
}
