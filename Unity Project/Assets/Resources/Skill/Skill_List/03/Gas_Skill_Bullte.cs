using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gas_Skill_Bullte : MonoBehaviour
{
    float scaleSpeed = 2.0f;
    float time;
    public float distance;
    public GameObject Boom;
    BoxCollider2D boxCollider2D;
    public float add;
    private void Awake()
    {
        time = 0;
        StartCoroutine("SuRuTanDo");
    }
    private void Update()
    {
        time += Time.deltaTime;
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
        Boom_Eff.GetComponent<Transform>().localScale = new Vector3(
            Boom_Eff.GetComponent<Transform>().localScale.x * 2,
            Boom_Eff.GetComponent<Transform>().localScale.y * 2,
            1);
        Boom_Eff.GetComponent<Set_Damage>().SetDamage((int)(GetComponent<Set_Damage>().Damage() * add));
        Destroy(gameObject);
    }
    public void Set_Distance(float dis)
    {
        distance = dis;
    }
}
