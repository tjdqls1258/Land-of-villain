using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turring : MonoBehaviour
{
    public float Rota_Speed;
    private void Awake()
    {
        Set_all_Bullte(GetComponent<Skill_damage>().Damage());
    }
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, Rota_Speed * Time.deltaTime));
    }
    public void Set_all_Bullte(int Damage)
    {
        Transform[] allChildren = GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            if (child.name == transform.name)
                continue;
            child.GetComponent<Skill_damage>().Set_Damage(Damage);
            Debug.Log(child.name);
        }
    }
}
