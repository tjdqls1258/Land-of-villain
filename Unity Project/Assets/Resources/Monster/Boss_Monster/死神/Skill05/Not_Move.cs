using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Not_Move : MonoBehaviour
{
    public float Move_speed = 2.0f;
    void Awake()
    {
        GameObject Player = GameObject.Find("Player");
        Vector2 vec = new Vector2(Player.transform.position.x - transform.position.x,
            Player.transform.position.y - transform.position.y);

        float angle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
        Quaternion angleAxis = Quaternion.AngleAxis(angle - 90f, Vector3.forward);

        transform.rotation = angleAxis;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.up, Move_speed * Time.deltaTime);
    }
}
