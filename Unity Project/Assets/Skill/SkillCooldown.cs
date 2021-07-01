using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SkillCooldown : MonoBehaviour
{
    bool atkdelay = false;
    bool weaponskilldelay = false;
    bool armorskilldelay = false;
    bool helmetskilldelay = false;
    bool acceskilldelay = false;

    bool ismeele = true;

    public List<GameObject> FoundObjects;
    public float shortDis;

    private Rigidbody2D rigid;
    private GameObject Monster;
    public Vector2 Monsterpos;

    public GameObject meeleattack;
    public GameObject P_bullet;

    Player_Item item_skill;

    public float mel_ATK;
    public Image img_ATK;

    float Weapon_CoolTime;
    float Amor_CoolTime;
    float helmat_CoolTime;
    float acc_CoolTime;

    public Image img_Weapon_Cool;
    public Image img_Amor_Cool;
    public Image img_helmat_Cool;
    public Image img_acc_Cool;

    void Awake()
    {
        item_skill = GetComponent<Player_Item>();             
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region 스테이지 넘어갈때마다 몬스터 검색
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
    #endregion

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
            item_skill.Weapon.GetComponent<Item_stats>().Skill_Set();
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
            item_skill.Armor.GetComponent<Item_stats>().Skill_Set();
            item_skill.Armor.GetComponent<Item_stats>().skill.Skill_Action();
            Amor_CoolTime = item_skill.Armor.GetComponent<Item_stats>().CoolTime;

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
            if(item_skill.Hat == null)
            {
                return;
            }
            item_skill.Hat.GetComponent<Item_stats>().Skill_Set();
            item_skill.Hat.GetComponent<Item_stats>().skill.Skill_Action();
            helmat_CoolTime = item_skill.Hat.GetComponent<Item_stats>().CoolTime;

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
            item_skill.Ring.GetComponent<Item_stats>().skill.Skill_Action();
            Amor_CoolTime = item_skill.Ring.GetComponent<Item_stats>().CoolTime;

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
        Monster = null;
        shortDis = 1000f;
        foreach (GameObject found in FoundObjects)
        {
            if (found == null)
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
        if (ismeele)
        {
            float angle = Mathf.Atan2(Monsterpos.y - transform.position.y
                , Monsterpos.x - transform.position.x) * Mathf.Rad2Deg; //몬스터를 바라보는 각도       
            Instantiate((GameObject)Resources.Load(("Skill/P_Meele_Atk"), typeof(GameObject)),
                transform.position, Quaternion.AngleAxis(angle - 90, Vector3.forward));
        }
        else
        {        
            Debug.Log(Monsterpos);
            Instantiate(P_bullet, transform.position, transform.rotation);
            //원거리 공격 추후에 근,원거리무기 판별 조건 필요
        }
        Debug.Log("shoot");
        atkdelay = false;
    }
    IEnumerator MeeleAttacktime()
    {
        float Cool_Dwon = mel_ATK;
        while (Cool_Dwon >= 0.0f)
        {
            img_ATK.fillAmount = (Cool_Dwon / mel_ATK);
            Cool_Dwon -= Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        yield return new WaitForSeconds(0.1f);
    }

    IEnumerator WeaponSkill()
    {
        float Cool_Dwon = Weapon_CoolTime;
        while (Cool_Dwon >= 0.0f)
        {
            img_Weapon_Cool.fillAmount = (Cool_Dwon / Weapon_CoolTime);
            Cool_Dwon -= Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        weaponskilldelay = false;
    }

    IEnumerator ArmorSkill()
    {
        float Cool_Dwon = Amor_CoolTime;
        while (Cool_Dwon >= 0.0f)
        {
            img_Amor_Cool.fillAmount = (Cool_Dwon / Amor_CoolTime);
            Cool_Dwon -= Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        armorskilldelay = false;
    }

    IEnumerator HelmetSkill()
    {
        float Cool_Dwon = helmat_CoolTime;
        while (Cool_Dwon >= 0.0f)
        {
            img_helmat_Cool.fillAmount = (Cool_Dwon / helmat_CoolTime);
            Cool_Dwon -= Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        helmetskilldelay = false;
    }

    IEnumerator AcceSkill()
    {
        float Cool_Dwon = acc_CoolTime;
        while (Cool_Dwon >= 0.0f)
        {
            img_acc_Cool.fillAmount = (Cool_Dwon / acc_CoolTime);
            Cool_Dwon -= Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        acceskilldelay = false;
    }
    #endregion
}