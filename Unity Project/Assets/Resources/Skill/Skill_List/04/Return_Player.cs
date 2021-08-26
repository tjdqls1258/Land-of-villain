using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Return_Player : MonoBehaviour
{
    Rigidbody2D rigid;
    public float Move_speed;
    public float distance;
    GameObject Player;

    private int Damage_s = 0;

    float time;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player");
        StartCoroutine("Do_It");
    }

    // Update is called once per frame
    IEnumerator Do_It()
    {
        float time = 0;
        while (distance > time)
        {
            time += Time.deltaTime;
            GetComponent<Set_Damage>().SetDamage((int)(Player.GetComponent<Player_Stat>().Get_P_State(2) * 0.75f));
            transform.position = Vector3.MoveTowards(transform.position, transform.position+ transform.up , Move_speed * Time.deltaTime);
            yield return null;
        }
        rigid.velocity = Vector3.zero;
        time = 0;
        while (distance > time)
        {
            time += Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, Move_speed * Time.deltaTime);
            yield return null;
        }
        Destroy(gameObject);
    }
    public int Damage()
    {
        return Damage_s;
    }
    public void Set_Damage(int dam)
    {
        this.Damage_s = dam;
    }
}
