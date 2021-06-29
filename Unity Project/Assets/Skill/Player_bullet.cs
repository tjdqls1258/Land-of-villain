using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_bullet : MonoBehaviour
{
    private GameObject Player;
    Rigidbody2D rigid;
    public float Move_speed;
    private Vector3 monsterpos;
    private Vector2 movedir;
    // Start is called before the first frame update
    void Awake()
    {
        monsterpos = GameObject.Find("Player").GetComponent<SkillCooldown>().Monsterpos;
        Player = GameObject.Find("Player");
        movedir = monsterpos - Player.transform.position;//몬스터좌표 - 내좌표 = 진행방향
        rigid = GetComponent<Rigidbody2D>();
        StartCoroutine("Die");
    }

    // Update is called once per frame
    void Update()
    {       
        rigid.AddForce(movedir * Move_speed, ForceMode2D.Force);
        Debug.DrawLine(movedir, Player.transform.position, Color.black);
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
