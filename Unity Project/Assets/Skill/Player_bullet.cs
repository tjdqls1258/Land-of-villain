﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_bullet : MonoBehaviour
{
    private GameObject Player;
    Rigidbody2D rigid;
    public float Move_speed;
    public float Destory_self_this;
    private Vector3 monsterpos;
    float time;
    //private Vector2 movedir;
    // Start is called before the first frame update
    void Awake()
    { 
        Player = GameObject.Find("Player");
        //monsterpos = GameObject.Find("Player").GetComponent<SkillCooldown>().Monsterpos;

        //if (Player.GetComponent<SkillCooldown>().Get_Monster() != null)
        //{
        //    float angle = Mathf.Atan2(monsterpos.y - transform.position.y
        //        , monsterpos.x - transform.position.x) * Mathf.Rad2Deg; //몬스터를 바라보는 각도
        //    this.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward); 
        //    // 회전
        //}
        ////Damage_s += Player.GetComponent<Player_Stat>().Get_P_State(2); 

        //rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.up, Move_speed * Time.deltaTime);
        //Debug.DrawLine(transform.up * 10f, Player.transform.position, Color.black);
        if (!GameManager.isPause)
        {
            time += Time.deltaTime;
            if (time >= Destory_self_this)
            {
                Destroy(gameObject);
            }
        }
    }
}
