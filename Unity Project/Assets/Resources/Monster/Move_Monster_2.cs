using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Monster_2 : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed;
    [SerializeField]
    private float moveSpeed;

    SpriteRenderer rend;
    Animator animator;
    Monster_stats monster_Stats;

    private Rigidbody2D rigid;
    private GameObject Player;

    public GameObject Monster_Bullet;
    Quaternion angleAxis;
    float angle;

    float time;
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
            move();
            LookAt_Player();
            time += Time.deltaTime;
            if (time >= 1.0f)
            {
                Fire();
                time = 0;
            }
            Set_Ainmate();
        }
    }

    void LookAt_Player()//플레이어를 바라보게 하는 함수
    {
        Vector2 vec = Vector2.zero;//초기화

        if (transform != null)
        {
            vec = new Vector2(Player.transform.position.x - transform.position.x,
                Player.transform.position.y - transform.position.y);
            //트렌스폼 찾으면 플레이어를 바라보는 벡터구함.
        }

        angle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg; //y와 x의 좌표를 탄젠트해서 각도를 구함
        angleAxis = Quaternion.AngleAxis(angle - 90f, Vector3.forward); //회전할 Z축 각도 저장 
    }

    void move()
    {
        //플레이어한테 이동
        if (Vector3.Distance(transform.position, Player.transform.position) > monster_Stats.Atk_dir)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                Player.transform.position, moveSpeed * Time.deltaTime);
        }
    }
    void Fire()
    {
        if (!(Vector3.Distance(transform.position, Player.transform.position) > monster_Stats.Atk_dir))
        {
            animator.SetBool("ATK", true);

            //Instantiate(Monster_Bullet, transform.position, angleAxis);
            GameObject Bullet = Instantiate(Monster_Bullet, transform.position, angleAxis);
            Bullet.GetComponent<Monster_Bullet>().Set_Damage(
                GetComponent<Monster_stats>().give_damage());
        }
        else
        {
            animator.SetBool("ATK", false);
        }
    }
    void Set_Ainmate()
    {
        
        float taget_see_angle = angle + 180.0f;
        if ((taget_see_angle <= 45.0f) || (taget_see_angle > 315.0f))
        {
            animator.SetBool("Back", false);
            animator.SetBool("Foward", false);
            animator.SetBool("Right", true);
            rend.flipX = true;
        }
        if((taget_see_angle > 45.0f) && (taget_see_angle <= 135.0f))
        {
            animator.SetBool("Back", false);
            animator.SetBool("Foward", true);
            animator.SetBool("Right", false);
            rend.flipX = false;
        }
        if ((taget_see_angle > 135.0f) && (taget_see_angle <= 225.0f))
        {
            animator.SetBool("Back", false);
            animator.SetBool("Foward", false);
            animator.SetBool("Right", true);
            rend.flipX = false;
        }
        if ((taget_see_angle > 225.0f) && (taget_see_angle <= 315.0f))
        {
            animator.SetBool("Back", true);
            animator.SetBool("Foward", false);
            animator.SetBool("Right", false);
            rend.flipX = false;

        }
    }
}


