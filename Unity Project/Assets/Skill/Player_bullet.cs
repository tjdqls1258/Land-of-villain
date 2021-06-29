using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_bullet : MonoBehaviour
{
    private GameObject Player;
    Rigidbody2D rigid;
    public float Move_speed;
    private Vector3 monsterpos;
    //private Vector2 movedir;
    // Start is called before the first frame update
    void Awake()
    { 
        Player = GameObject.Find("Player");
        monsterpos = GameObject.Find("Player").GetComponent<SkillCooldown>().Monsterpos;
        //movedir = (monsterpos - transform.position).normalized;//몬스터좌표 - 내좌표 = 진행방향
        float angle = Mathf.Atan2(monsterpos.y - transform.position.y
            , monsterpos.x - transform.position.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        rigid = GetComponent<Rigidbody2D>();
        StartCoroutine("Die");
    }

    // Update is called once per frame
    void Update()
    {       
        rigid.AddForce(transform.up * Move_speed, ForceMode2D.Force);
        Debug.DrawLine(transform.up * 10f, Player.transform.position, Color.black);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            Destroy(gameObject);
        }
    }
    IEnumerator Die()
    {
        yield return new WaitForSecondsRealtime(5.0f);
        Destroy(gameObject);
    }
}
