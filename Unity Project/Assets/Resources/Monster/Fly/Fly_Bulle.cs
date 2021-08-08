using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly_Bulle : MonoBehaviour
{
    float time;
    private void Awake()
    {
        time = 0;
    }
    void Update()
    {
        if (!GameManager.isPause)
        {
            time += Time.deltaTime;
            if (time >= 5)
            {
                Destroy(gameObject);
            }
        }
    }
    public void Set_all_Bullte(int Damage)
    {
        Transform[] allChildren = GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            if (child.name == transform.name)
                return;
            child.GetComponent<Monster_Bullet>().Set_Damage(Damage);
            Debug.Log(child.name);
        }
    }
}
