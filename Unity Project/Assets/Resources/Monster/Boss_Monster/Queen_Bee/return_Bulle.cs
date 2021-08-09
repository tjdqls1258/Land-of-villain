using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class return_Bulle : MonoBehaviour
{
    Rigidbody2D rigid;
    public float Move_speed;

    private int Damage_s = 0;

    float time;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        StartCoroutine("Do_It");
    }

    // Update is called once per frame
    void Update()
    {
        rigid.AddForce(transform.up * Move_speed, ForceMode2D.Force);
    }
    IEnumerator Do_It()
    {
        yield return new WaitForSeconds(1.0f);
        rigid.velocity = Vector3.zero;
        transform.Rotate(new Vector3(0, 0, 180));
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

    }

    public int Damage()
    {
        return Damage_s;
    }
    public void Set_Damage(int dam)
    {
        this.Damage_s = dam;
    }
}
