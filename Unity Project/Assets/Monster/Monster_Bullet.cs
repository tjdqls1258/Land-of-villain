using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Bullet : MonoBehaviour
{
    Rigidbody2D rigid;
    public float Move_speed;
    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        StartCoroutine("Die");
    }

    // Update is called once per frame
    void Update()
    {
        rigid.AddForce(transform.up * Move_speed, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
    IEnumerator Die()
    {
        yield return new WaitForSecondsRealtime(5f);
        Destroy(gameObject);
    }
}
