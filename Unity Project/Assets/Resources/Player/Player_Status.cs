using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Status : MonoBehaviour
{
    public int damage;
    public GameObject Player;
    [SerializeField] private GameObject Player_die_UI;

    public bool isclear = false;
    private bool isinvincible = false;
    private bool Boom = false;
    public static Player_Status Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame

    void Get_damange(int damage)
    {
        int Setting_Hp = Player.GetComponent<Player_Stat>().Get_P_State(1) - damage;
        Player.GetComponent<Player_Stat>().Set_P_State(1, Setting_Hp);
        if (Player.GetComponent<Player_Stat>().Get_P_State(1) <= 0) //체력 0 되면 사망
        {
            GameManager.isPause = true;
            Player_die_UI.SetActive(true);
            Time.timeScale = 0.0f;
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
        if ((other.gameObject.tag == "Boom") && (Boom == false)) 
        {
            Boom = true;
            //충돌한 객체의 컴퍼넌트에서 데미지 받아옴
            Get_damange(other.GetComponent<Boom>().Damage());
            StartCoroutine("CollisionBoom");
        }
        if ((other.gameObject.tag == "Monster_Skill") && (isinvincible == false))
        {
            isinvincible = true;
            //충돌한 객체의 컴퍼넌트에서 데미지 받아옴
            Get_damange(other.GetComponent<Skill_damage>().Damage());
            StartCoroutine("CollisionINvincible");
        }
    }
    public bool isinvincible_Check()
    {
        return isinvincible;
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
    IEnumerator CollisionBoom()
    {
        yield return new WaitForSeconds(0.1f);
        Boom = false;
    }
    public void ReturnToStart()
    {
        GameManager.isPause = false;
        SceneManager.LoadScene("Start_Secen");
        Destroy(Player.gameObject);
        Player_die_UI.SetActive(false);
        Time.timeScale = 1.0f;
        Debug.Log("load start");
    }

    public void Restart()
    {
        GameManager.isPause = false;
        SceneManager.LoadScene("TestSecen");
        Destroy(Player.gameObject);
        Player_die_UI.SetActive(false);
        Time.timeScale = 1.0f;
        Debug.Log("restart test");
    }
}
