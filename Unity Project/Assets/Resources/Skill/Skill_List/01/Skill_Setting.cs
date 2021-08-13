using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Setting : MonoBehaviour
{
    float scaleSpeed = 2.0f;
    float time;
    public float distance;
    public GameObject Boom;
    BoxCollider2D boxCollider2D;
    Rigidbody2D rigid;
    public float add;
    public float Move_speed;
    private void Awake()
    {
        time = 0;
        StartCoroutine("SuRuTanDo");
        rigid = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        time += Time.deltaTime;
        if (rigid)
        {
            rigid.AddForce(transform.up * Move_speed, ForceMode2D.Force);
        }
        if (time <= (distance * 0.5f))
        {
            transform.localScale = new Vector3(transform.localScale.x + 1f * scaleSpeed * Time.deltaTime,
                transform.localScale.y + 1f * scaleSpeed * Time.deltaTime, 0);
        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x - 1f * scaleSpeed * Time.deltaTime,
               transform.localScale.y - 1f * scaleSpeed * Time.deltaTime, 0);
        }
    }
    IEnumerator SuRuTanDo()
    {
        yield return new WaitForSecondsRealtime(distance);
        GameObject Boom_Eff = Instantiate(Boom, transform.position, Quaternion.identity);
        Boom_Eff.GetComponent<Set_Damage>().SetDamage((int)(GetComponent<Skill_Danamge>().Damage() * add));
        Destroy(gameObject);
    }
    public void Set_Distance(float dis)
    {
        distance = dis;
    }
}
