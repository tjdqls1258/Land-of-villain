using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_monster : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float Hp;

    public float damage;

    private Rigidbody2D rigid;
    private GameObject Player;
    private Transform transform;

    void Awake()
    {
        Player = GameObject.Find("Player");
        transform = GetComponent<Transform>();
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        LookAt_Player();
        move();
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

        float angle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg; //y와 x의 좌표를 탄젠트해서 각도를 구함
        Quaternion angleAxis = Quaternion.AngleAxis(angle - 90f, Vector3.forward); //회전할 Z축 각도 저장
        Quaternion rotation = Quaternion.Slerp(transform.rotation, angleAxis, rotateSpeed * Time.deltaTime);
        //회전 속도

        transform.rotation = rotation; // 회전
    }

    void move()
    {
        //플레이어한테 이동
        transform.position = Vector3.MoveTowards(transform.position, 
            Player.transform.position, moveSpeed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("coll");
        if (other.gameObject.tag == "Player") //플레이어(임시 스킬로 대체할 예정)와 충돌시
        {
            //충돌한 객체의 컴퍼넌트에서 데미지 받아옴
            damage = other.GetComponent<Test>().Dam;
            Get_damange(damage); // 데미지 입음
        }
    }

    void Get_damange(float damage)
    {
        Hp -= damage;
        if(Hp <= 0 ) //체력 0 되면 사망
        {
            die();
        }
    }
    void die()
    {
        //Instantiate(item, transform.position); //아이템 생성
        Destroy(this);
    }
}
