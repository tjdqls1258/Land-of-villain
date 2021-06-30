using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkillCooldown : MonoBehaviour
{
    bool atkdelay = false;
    bool weaponskilldelay = false;
    bool armorskilldelay = false;
    bool helmetskilldelay = false;
    bool acceskilldelay = false;

    bool ismeele = false;

    public List<GameObject> FoundObjects;
    public float shortDis;

    private Rigidbody2D rigid;
    private GameObject Monster;
    public Vector2 Monsterpos;

    public GameObject meeleattack;
    public GameObject P_bullet;

    Player_Item item_skill;

    float Weapon_CoolTime;
    // Start is called before the first frame update
    void Awake()
    {
        item_skill = GetComponent<Player_Item>();             
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        FoundObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag("Monster"));
        Monster = FoundObjects[0];
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public GameObject Get_Monster()
    {
        return Monster;
    }

    #region activate skill
    public void baseatk()
    {
        if (!atkdelay)
        {
            atkdelay = true;
            //기본공격 실행
            StartCoroutine("BaseAttack");
            Debug.Log("atk success");
        }
        else
        {
            Debug.Log("atk cooltime");
        }
    }

    public void weaponskill()
    {
        if (!weaponskilldelay)
        {
            weaponskilldelay = true;
            //무기스킬 실행
            item_skill.Weapon.GetComponent<Item_stats>().skill.Skill_Action();
            Weapon_CoolTime = item_skill.Weapon.GetComponent<Item_stats>().CoolTime;
            StartCoroutine("WeaponSkill");
            Debug.Log("weaponskill success");
        }
        else
        {
            Debug.Log("weaponskill cooltime");
        }
    }

    public void armorskill()
    {
        if (!armorskilldelay)
        {
            armorskilldelay = true;
            //갑옷스킬 실행
            StartCoroutine("ArmorSkill");
            Debug.Log("armorskill success");
        }
        else
        {
            Debug.Log("armorskill cooltime");
        }
    }

    public void helmetskill()
    {
        if (!helmetskilldelay)
        {
            helmetskilldelay = true;
            //투구스킬
            StartCoroutine("HelmetSkill");
            Debug.Log("helmetskill success");
        }
        else
        {
            Debug.Log("helmetskill cooltime");
        }
    }

    public void acceskill()
    {
        if (!acceskilldelay)
        {
            acceskilldelay = true;
            //악세서리스킬 실행
            StartCoroutine("AcceSkill");
            Debug.Log("acceskill success");
        }
        else
        {
            Debug.Log("acceskill cooltime");
        }
    }
    #endregion

    #region cooldown coroutine
    IEnumerator BaseAttack()
    {
        yield return new WaitForSeconds(0.3f);
        if (ismeele)
        {
            meeleattack.gameObject.SetActive(true);//근거리공격
            StartCoroutine("MeeleAttacktime");
            meeleattack.gameObject.SetActive(false);
        }
        else
        {
            Monster = null;
            shortDis = 1000f;
            foreach (GameObject found in FoundObjects)
            {
                if(found == null)
                {
                    continue;
                }
                float Distance = Vector3.Distance(gameObject.transform.position, found.transform.position);

                if (Distance < shortDis) // 위에서 잡은 기준으로 거리 재기
                {
                    Monster = found;
                    shortDis = Distance;
                    Monsterpos = Monster.transform.position;
                }
            }
            Debug.Log(Monsterpos);
            Instantiate(P_bullet, transform.position, transform.rotation);
            //원거리 공격 추후에 근,원거리무기 판별 조건 필요
        }
        Debug.Log("shoot");
        atkdelay = false;
    }
    IEnumerator MeeleAttacktime()
    {
        yield return new WaitForSeconds(0.1f);
    }

    IEnumerator WeaponSkill()
    {
        yield return new WaitForSeconds(3.0f);
        weaponskilldelay = false;
    }

    IEnumerator ArmorSkill()
    {
        yield return new WaitForSeconds(10.0f);
        armorskilldelay = false;
    }

    IEnumerator HelmetSkill()
    {
        yield return new WaitForSeconds(10.0f);
        helmetskilldelay = false;
    }

    IEnumerator AcceSkill()
    {
        yield return new WaitForSeconds(30.0f);
        acceskilldelay = false;
    }
    #endregion
}