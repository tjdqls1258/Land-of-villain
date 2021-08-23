using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly_Move : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed;
    public float moveSpeed;

    private Rigidbody2D rigid;
    private GameObject Player;

    SpriteRenderer rend;
    Animator animator;
    Monster_stats monster_Stats;

    float angle;
    Quaternion angleAxis;

    public GameObject stageManger;
    public GameObject Monster_Bullet;

    float time;

    bool Move_;
    void Awake()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Foward", true);
        Player = GameObject.Find("Player");
        monster_Stats = GetComponent<Monster_stats>();
        rigid = GetComponent<Rigidbody2D>();
        angleAxis = Quaternion.identity;
        rend = GetComponent<SpriteRenderer>();
        angle = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player == null)
        {
            return;
        }
        if (!GameManager.isPause)
        {
            LookAt_Player();
            move();
            time += Time.deltaTime;
            if (time >= 1.0f)
            {
                Fire();
                time = 0;
            }

        }
    }
    void Fire()
    {
        if (!(Vector3.Distance(transform.position, Player.transform.position) > monster_Stats.Atk_dir))
        {
            animator.SetBool("Move", false);
            animator.SetBool("ATK", true);

            //Instantiate(Monster_Bullet, transform.position, angleAxis);
            Quaternion Shot_angle = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
            GameObject Bullet = Instantiate(Monster_Bullet, transform.position, Shot_angle);

            Bullet.GetComponent<Fly_Bulle>().Set_all_Bullte(
                GetComponent<Monster_stats>().give_damage());
        }
        else
        {
            animator.SetBool("ATK", false);
        }
    }
    void LookAt_Player()//플레이어를 바라보게 하는 함수
    {
        Vector2 vec = Vector2.zero;//초기화
        if (Player == null)
        {
            return;
        }
        if (transform != null)
        {
            vec = new Vector2(Player.transform.position.x - transform.position.x,
                Player.transform.position.y - transform.position.y);
            //트렌스폼 찾으면 플레이어를 바라보는 벡터구함.
        }

        angle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg; //y와 x의 좌표를 탄젠트해서 각도를 구함
        angleAxis = Quaternion.AngleAxis(angle - 270f, Vector3.forward); //회전할 Z축 각도 저장
        Quaternion rotation = Quaternion.Slerp(transform.rotation, angleAxis, rotateSpeed * Time.deltaTime);
        //회전 속도

        transform.rotation = rotation; // 회전
    }
    void move()
    {
        animator.SetBool("Move", true);
        //플레이어한테 이동
        if (Vector3.Distance(transform.position, Player.transform.position) > monster_Stats.Atk_dir)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                Player.transform.position, moveSpeed * Time.deltaTime);
        }
    }

}
