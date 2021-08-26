using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield_Self : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject Player;
    float angle;
    void Awake()
    {
        Player = GameObject.Find("Player");
        angle = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Player.transform.position;

        angle = Mathf.Atan2(Joystick.inputDirection.y
                , Joystick.inputDirection.x) * Mathf.Rad2Deg;
        gameObject.transform.rotation = Quaternion.AngleAxis(angle -180, Vector3.forward);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Monster_Bullet")
        {
            Destroy(collision.gameObject);
        }
    }

}
