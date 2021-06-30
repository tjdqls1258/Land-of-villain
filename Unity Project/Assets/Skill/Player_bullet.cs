using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_bullet : MonoBehaviour
{
    private GameObject Player;
    Rigidbody2D rigid;
    public float Move_speed;
    private Vector3 monsterpos;

    int Damage_s;

    // private Vector2 movedir;
    void Awake()
    { 
        Player = GameObject.Find("Player");
        monsterpos = GameObject.Find("Player").GetComponent<SkillCooldown>().Monsterpos;

        if (Player.GetComponent<SkillCooldown>().Get_Monster() != null)
        {
            float angle = Mathf.Atan2(monsterpos.y - transform.position.y
                , monsterpos.x - transform.position.x) * Mathf.Rad2Deg; // 몬스터를 바라보는 각도
            this.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward); 
            // 회전
        }
        Damage_s += Player.GetComponent<Player_Stat>().Get_P_State(2); 

        rigid = GetComponent<Rigidbody2D>();
        StartCoroutine("Die");
    }

    void Update()
    {       
        rigid.AddForce(transform.up * Move_speed, ForceMode2D.Force);
        Debug.DrawLine(transform.up * 10f, Player.transform.position, Color.black);
    }

    IEnumerator Die()
    {
        yield return new WaitForSecondsRealtime(5.0f);
        Destroy(gameObject);
    }
<<<<<<< HEAD
    public int Damage()
    {
        return Damage_s;
    }
=======

    public float Damage()
    {
        return Damage_s;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.tag == "Monster")
        //{
        //    Destroy(gameObject);
        //}
    }
>>>>>>> 7c2062ec2f04f0682a7483a1af07664210d46a63
}
