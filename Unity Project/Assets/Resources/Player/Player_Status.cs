using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Status : MonoBehaviour
{
    public GameObject Player;
    SpriteRenderer renderer;
    [SerializeField] private GameObject Player_die_UI;

    public bool isclear = false;
    private bool isinvincible = false;
    private bool Boom = false;
    public static Player_Status Instance;
    public float Debuff_DEF = 0;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame

    public void Get_damange(int damage)
    {
        int Setting_Hp = (damage - (int)(Player.GetComponent<Player_Stat>().Get_P_State(3) * 0.2f));
        if(Setting_Hp < 1)
        {
            Setting_Hp = 1;
        }
        Setting_Hp = Player.GetComponent<Player_Stat>().Get_P_State(1) - Setting_Hp;
        Player.GetComponent<Player_Stat>().Set_P_State(1, Setting_Hp);
        if (Player.GetComponent<Player_Stat>().Get_P_State(1) <= 0) //체력 0 되면 사망
        {
            GetComponent<Player_Stat>().Return_Hight_Score();
            GameManager.isPause = true;
            Player_die_UI.SetActive(true);
            Time.timeScale = 0.0f;
        }
        renderer.color = new Color(1, 0, 0);
        Invoke("Back", 0.1f);
    }
    void Back()
    {
        renderer.color = new Color(1, 1, 1);
    }
    public void Player_Die()
    {
        GetComponent<Player_Stat>().Return_Hight_Score();
        GameManager.isPause = true;
        Player_die_UI.SetActive(true);
        Time.timeScale = 0.0f;
    }
    public GameObject Get_Player_die_UI()
    {
        return Player_die_UI;
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
            GetComponent<Player_Stat>().Set_P_State(1, GetComponent<Player_Stat>().Get_P_State(0));
            GetComponent<item_info>().item_info_Set(false);
            GetComponent<Player_Stat>().N_Stages++;
            GameObject.Find("Camera").GetComponent<BGM_Saver>().Setting_BGM();
            if(GetComponent<Player_Stat>().N_Stages == 36)
            {
                Social.ReportProgress(GPGSIds.achievement, 100f, null);
            }
            if (GetComponent<Player_Stat>().N_Stages == 100)
            {
                Social.ReportProgress(GPGSIds.achievement_100, 100f, null);
            }
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
        if ((other.gameObject.tag == "Money"))
        {
            GetComponent<Player_Stat>().Set_P_State(6, GetComponent<Player_Stat>().Get_P_State(6) + other.GetComponent<Money_Stats>().Get_Money_Value());
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

    IEnumerator CollisionINvincible()
    {     
        yield return new WaitForSeconds(0.2f);
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
