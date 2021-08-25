using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Find_Gate : MonoBehaviour
{
    GameObject Gate;
    float angle;
    Vector2 vec;
    void Awake()
    {
        vec = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        Gate = GameObject.Find("Gate(Clone)");
        if (Gate != null)
        {
            vec = new Vector2(Gate.transform.position.x - transform.position.x, Gate.transform.position.y - transform.position.y);
            angle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;

            Quaternion angleAxis = Quaternion.AngleAxis(angle - 90f, Vector3.forward); //회전할 Z축 각도 저장
            Quaternion rotation = Quaternion.Slerp(transform.rotation, angleAxis, 1000 * Time.deltaTime);

            transform.rotation = rotation; // 회전
        }
    }
}
