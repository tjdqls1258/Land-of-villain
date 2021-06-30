using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_monster : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed;
    [SerializeField]
    private float moveSpeed;

    private Rigidbody2D rigid;
    private GameObject Player;

    void Awake()
    {
        Player = GameObject.Find("Player");
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        if (Player == null)
        {
            return;
        }
        LookAt_Player();
        move();

        if (!GameManager.isPause)
        {
            LookAt_Player();
            move();
        }

    }

    void LookAt_Player() // 플레이어를 바라보게 하는 함수
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
            // 트렌스폼 찾으면 플레이어를 바라보는 벡터구함.
        }

        float angle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg; // y와 x의 좌표를 탄젠트해서 각도를 구함
        Quaternion angleAxis = Quaternion.AngleAxis(angle - 90f, Vector3.forward); // 회전할 Z축 각도 저장
        Quaternion rotation = Quaternion.Slerp(transform.rotation, angleAxis, rotateSpeed * Time.deltaTime);
        // 회전 속도

        transform.rotation = rotation; // 회전
    }

    void move()
    {
        // 플레이어한테 이동
        transform.position = Vector3.MoveTowards(transform.position, 
            Player.transform.position, moveSpeed);
    }

  
}
