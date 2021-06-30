using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Status : MonoBehaviour
{
    private int Hp = 100;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Get_damange(int damage)
    {

        Hp -= damage;
        if (Hp <= 0) //체력 0 되면 사망
        {
            die();
        }
        Debug.Log(Hp);
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
