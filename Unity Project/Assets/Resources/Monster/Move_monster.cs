using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_monster : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed;
    public float moveSpeed;

    private Rigidbody2D rigid;
    private GameObject Player;

    Animator animator;
    SpriteRenderer rend;
    float angle;
    void Awake()
    {
        rend = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        Player = GameObject.Find("Player");
        rigid = GetComponent<Rigidbody2D>();
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
            Set_Ainmate();
            move();
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
        Quaternion angleAxis = Quaternion.AngleAxis(angle - 90f, Vector3.forward); //회전할 Z축 각도 저장
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
        if ((taget_see_angle > 45.0f) && (taget_see_angle <= 135.0f))
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
    void move()
    {
        //플레이어한테 이동
        transform.position = Vector3.MoveTowards(transform.position, 
            Player.transform.position, moveSpeed * Time.deltaTime);
    }

  
}
