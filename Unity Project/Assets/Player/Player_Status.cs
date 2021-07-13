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
    //[SerializeField] private GameObject Player_die_UI;

    public bool isclear = false;
    private bool isinvincible = false;

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
        Player.GetComponent<Player_Stat>().Set_P_State(1, Setting_Hp);
        if (Player.GetComponent<Player_Stat>().Get_P_State(1) <= 0) //체력 0 되면 사망
        {
            
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.tag == "Monster_Bullet") && (isinvincible == false)) //몬스터 원거리 공격과 충돌시
        {
            isinvincible = true;
            //충돌한 객체의 컴퍼넌트에서 데미지 받아옴
            Get_damange(other.GetComponent<Monster_Bullet>().Damage());
            StartCoroutine("CollisionINvincible");
            Destroy(other.gameObject);
        }        
        if (other.gameObject.tag == "Gate")
        {
            isclear = true;
            GetComponent<Player_Stat>().N_Stages++;
            Destroy(other.gameObject);
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if ((other.gameObject.tag == "Monster") && (isinvincible == false))
        {
            isinvincible = true;
            Get_damange(other.GetComponent<Monster_stats>().give_damage());
            StartCoroutine("CollisionINvincible");
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        isclear = false;
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public int Damage()
    {
        return damage;
    }

    IEnumerator CollisionINvincible()
    {     
        yield return new WaitForSeconds(0.1f);
        isinvincible = false;
    }
}
