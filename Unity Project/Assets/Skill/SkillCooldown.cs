using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCooldown : MonoBehaviour
{
    bool atkdelay = false;
    bool skill1delay = false;
    bool skill2delay = false;
    bool skillultdelay = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region activate skill
    public void baseatk()
    {
        if(!atkdelay)
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

    public void skill1()
    {
        if (!skill1delay)
        {
            skill1delay = true;
            //스킬1 실행
            StartCoroutine("Skill1");
            Debug.Log("skill1 success");
        }
        else
        {
            Debug.Log("skill1 cooltime");
        }
    }

    public void skill2()
    {
        if (!skill2delay)
        {
            skill2delay = true;
            //스킬2 실행
            StartCoroutine("Skill2");
            Debug.Log("skill2 success");
        }
        else
        {
            Debug.Log("skill2 cooltime");
        }
    }

    public void skillult()
    {
        if (!skillultdelay)
        {
            skillultdelay = true;
            //궁극기 실행
            StartCoroutine("Skillult");
            Debug.Log("skillult success");
        }
        else
        {
            Debug.Log("skillult cooltime");
        }
    }
    #endregion

    #region cooldown coroutine
    IEnumerator BaseAttack()
    {
        yield return new WaitForSeconds(0.5f);
        atkdelay = false;
    }

    IEnumerator Skill1()
    {
        yield return new WaitForSeconds(3.0f);
        skill1delay = false;
    }

    IEnumerator Skill2()
    {
        yield return new WaitForSeconds(10.0f);
        skill2delay = false;
    }

    IEnumerator Skillult()
    {
        yield return new WaitForSeconds(30.0f);
        skillultdelay = false;
    }
    #endregion
}
