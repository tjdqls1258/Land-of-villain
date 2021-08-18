using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trrowing_Not : MonoBehaviour
{
    public float Move_speed;
    public float distance;
    Vector3 first;
    void Awake()
    {
        first = transform.position;
        GameObject Player = GameObject.Find("Player");
        Vector2 vec = new Vector2(Player.transform.position.x - transform.position.x,
            Player.transform.position.y - transform.position.y);

        float angle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
        Quaternion angleAxis = Quaternion.AngleAxis(angle - 90f, Vector3.forward);

        transform.rotation = angleAxis;

        StartCoroutine("Do_It");
    }

    IEnumerator Do_It()
    {
        float time = 0;
        while (distance > time)
        {
            time += Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.up, Move_speed * Time.deltaTime);
            yield return null;
        }
        time = 0;
        while (distance > time)
        {
            time += Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, first, Move_speed * Time.deltaTime);
            yield return null;
        }
        Destroy(gameObject);
    }
}
