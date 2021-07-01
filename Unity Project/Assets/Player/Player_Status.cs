using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Status : MonoBehaviour
{
    public static int healthMax = 100;  // 플레이어 캐릭터의 최대 체력을 저장할 정수형 변수
    public static int health = 100;     // 플레이어 캐릭터의 현재 체력을 저장할 정수형 변수
    public int damage;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Awake()
    {
        Player_Status.healthMax = 100;
        Player_Status.health = 100;
    }
    // Update is called once per frame
    void Update()
    {

    }

    void Get_damange(int damage)
    {
        int Setting_Hp = Player.GetComponent<Player_Stat>().Get_P_State(1) - damage;
        Player.GetComponent<Player_Stat>().Set_P_State(1,
            Setting_Hp);
        if (Player.GetComponent<Player_Stat>().Get_P_State(1) <= 0) //체력 0 되면 사망
        {
            die();
        }
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
