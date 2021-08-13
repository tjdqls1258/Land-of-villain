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
    bool isdash = false;
    public bool dashactive = false;

    bool ismeele;

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
        if (GetComponent<Player_Item>().Weapon != null)
        {
            ismeele = GetComponent<Player_Item>().Weapon.GetComponent<Item_stats>().meeleatk;
        }
        else { ismeele = false; }
    }

    #region 스테이지 넘어갈때마다 몬스터 검색
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    public void Load_New_Stage()
    {
        FoundObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag("Monster"));
        Monster = FoundObjects[0];
    }
    public GameObject Get_Monster()
    {
        return Monster;
    }
    #endregion

    #region activate skill
    public void baseatk()
    {
        if ((!atkdelay))
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
        if ((!weaponskilldelay) && (GetComponent<Player_Item>().Weapon != null))
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
        if ((!armorskilldelay) && (GetComponent<Player_Item>().Armor != null))
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
        if ((!helmetskilldelay) && (GetComponent<Player_Item>().Hat != null))
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
        if ((!acceskilldelay) && (GetComponent<Player_Item>().Ring != null))
        {
            acceskilldelay = true;
            if (item_skill.Ring == null)
            {
                return;
            }
            //악세서리스킬 실행
            item_skill.Ring.GetComponent<Item_stats>().Skill_Set();
            item_skill.Ring.GetComponent<Item_stats>().skill.Skill_Action();
            acc_CoolTime = item_skill.Ring.GetComponent<Item_stats>().CoolTime;

            StartCoroutine("AcceSkill");
            Debug.Log("acceskill success");
        }
        else
        {
            Debug.Log("acceskill cooltime");
        }
    }

    public void DashSkill()
    {
        if (!isdash)
        {
            isdash = true;
            dashactive = true;
            GetComponent<Movement2D>().moveSpeed *= 2;
            StartCoroutine("Dash");
            Debug.Log("dash success");
        }
        else
        {
            Debug.Log("dash cooltime");
        }
    }
    #endregion

    #region cooldown coroutine
    IEnumerator BaseAttack()
    {
        yield return new WaitForSeconds(0.3f);
        Monster = null;
        shortDis = 1000f;
        float angle = Mathf.Atan2(Monsterpos.y - transform.position.y
                , Monsterpos.x - transform.position.x) * Mathf.Rad2Deg;
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
            Instantiate((GameObject)Resources.Load(("Skill/P_Meele_Atk"), typeof(GameObject)),
                transform.position, Quaternion.AngleAxis(angle - 90, Vector3.forward));
        }
        else
        {
            
            GameObject Bullet = Instantiate(GetComponent<Player_Item>().Weapon.GetComponent<Item_stats>().Bullte,
                transform.position, Quaternion.AngleAxis(angle - 90, Vector3.forward));
            Bullet.GetComponent<Set_Damage>().SetDamage(GetComponent<Player_Stat>().Get_P_State(2));
        }
        Debug.Log("shoot");
        atkdelay = false;
    }
    public void Wepon_CoolTime_Delet(int HowMany)
    {
        if (Weapon_CoolTime - HowMany <= 0)
        {
            Weapon_CoolTime = 0;
        }
        else
        {
            Weapon_CoolTime = Weapon_CoolTime - HowMany;
        }
    }
    public void Amor_CoolTime_Delet(int HowMany)
    {
        if (Amor_CoolTime - HowMany <= 0)
        {
            Amor_CoolTime = 0;
        }
        else
        {
            Amor_CoolTime = Amor_CoolTime - HowMany;
        }
    }

    public void Hat_CoolTime_Delet(int HowMany)
    {
        if (helmat_CoolTime - HowMany <= 0)
        {
            helmat_CoolTime = 0;
        }
        else
        {
            helmat_CoolTime = helmat_CoolTime - HowMany;
        }
    }
    public void Ring_CoolTime_Delet(int HowMany)
    {
        if (acc_CoolTime - HowMany <= 0)
        {
            acc_CoolTime = 0;
        }
        else
        {
            acc_CoolTime = acc_CoolTime - HowMany;
        }
    }
    IEnumerator WeaponSkill()
    {
        float Cool_Dwon = Weapon_CoolTime;
        while (Weapon_CoolTime >= 0.0f)
        {
            img_Weapon_Cool.fillAmount = (Weapon_CoolTime / Cool_Dwon);
            Weapon_CoolTime -= Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        weaponskilldelay = false;
    }

    IEnumerator ArmorSkill()
    {
        float Cool_Dwon = Amor_CoolTime;
        while (Amor_CoolTime >= 0.0f)
        {
            img_Amor_Cool.fillAmount = (Amor_CoolTime / Cool_Dwon);
            Amor_CoolTime -= Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        armorskilldelay = false;
    }

    IEnumerator HelmetSkill()
    {
        float Cool_Dwon = helmat_CoolTime;
        while (helmat_CoolTime >= 0.0f)
        {
            img_helmat_Cool.fillAmount = (helmat_CoolTime / Cool_Dwon );
            helmat_CoolTime -= Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        helmetskilldelay = false;
    }

    IEnumerator AcceSkill()
    {
        float Cool_Dwon = acc_CoolTime;
        while (acc_CoolTime >= 0.0f)
        {
            img_acc_Cool.fillAmount = (acc_CoolTime/Cool_Dwon);
            acc_CoolTime -= Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        acceskilldelay = false;
    }

    IEnumerator Dash()
    {
        //float Cool_Dwon = acc_CoolTime;
        //while (Cool_Dwon >= 0.0f)
        //{
        //    img_acc_Cool.fillAmount = (Cool_Dwon / acc_CoolTime);
        //    Cool_Dwon -= Time.deltaTime;
        //    yield return new WaitForFixedUpdate();
        //}
        yield return new WaitForSeconds(1.0f);
        GetComponent<Movement2D>().moveSpeed /= 2;
        dashactive = false;
        yield return new WaitForSeconds(2.0f);
        isdash = false;
    }
    #endregion
}