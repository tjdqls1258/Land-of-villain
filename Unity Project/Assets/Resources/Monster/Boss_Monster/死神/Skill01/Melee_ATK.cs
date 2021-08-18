using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee_ATK : MonoBehaviour
{
    public float ATK_Speed;
    private void Awake()
    {
        GameObject Player = GameObject.Find("Player");
            Vector2 vec = new Vector2(Player.transform.position.x - transform.position.x,
                Player.transform.position.y - transform.position.y);

        float angle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
        Quaternion angleAxis = Quaternion.AngleAxis(angle - 45f, Vector3.forward);

        transform.rotation = angleAxis;
    }
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, -(ATK_Speed * Time.deltaTime)));
    }
}
