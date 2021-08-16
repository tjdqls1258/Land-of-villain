using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Boomber : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed;
    public float moveSpeed;

    private Rigidbody2D rigid;
    private GameObject Player;

    Animator animator;
    SpriteRenderer rend;
    float angle;

    public GameObject stageManger;
    public GameObject BOOM_eff;
    GameObject explote;

    bool Move_;
    void Awake()
    {
        Move_ = true;
        rend = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        stageManger = GameObject.Find("StageManager");
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
        if ((!GameManager.isPause)&&(Move_))
        {
            LookAt_Player();
            move();
            Fire();
        }
    }
    void Fire()
    {
        if (!(Vector3.Distance(transform.position, Player.transform.position) > 0.05f))
        {
            Move_ = false;
            animator.SetBool("ATK_1", true);
            Invoke("BOOM", 1f);
        }
    }
    void BOOM()
    {
        stageManger.GetComponent<StageManager>().monsterdead();
        explote = Instantiate(BOOM_eff, transform.position, Quaternion.identity);
        animator.SetBool("ATK_2", true);
        Invoke("Destroy_Self",0.6f);
    }
    void Destroy_Self()
    {
        Destroy(explote);
        Destroy(gameObject);
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
        Quaternion rotation = Quaternion.Slerp(transform.rotation, angleAxis, rotateSpeed * Time.deltaTime);
        //회전 속도

        transform.rotation = rotation; // 회전
    }
    void move()
    {
        //플레이어한테 이동
        transform.position = Vector3.MoveTowards(transform.position,
            Player.transform.position, moveSpeed *Time.deltaTime);
    }


}
