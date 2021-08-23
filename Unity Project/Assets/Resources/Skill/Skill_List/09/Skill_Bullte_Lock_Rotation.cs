using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Bullte_Lock_Rotation : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.identity;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Monster_Bullet")
        {
            Destroy(collision.gameObject);
        }
    }
}
