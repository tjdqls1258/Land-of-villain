using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Status : MonoBehaviour
{
    public static int healthMax = 100;  // 플레이어 캐릭터의 최대 체력을 저장할 정수형 변수
    public static int health = 100;     // 플레이어 캐릭터의 현재 체력을 저장할 정수형 변수
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Get_damange(int damage)
    {
        health -= damage;
        if (health <= 0) //체력 0 되면 사망
        {
            die();
        }
        Debug.Log(health);
    }

    void die()
    {
        SceneManager.LoadScene("Start_Secen");

        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Monster_Bullet") //몬스터 원거리 공격과 충돌시
        {
            //충돌한 객체의 컴퍼넌트에서 데미지 받아옴
            Get_damange(other.GetComponent<Monster_Bullet>().Damage());

            Destroy(other.gameObject);
        }
    }
}
