using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood_Arrow_Passive : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 Pos;
    void Awake()
    {
        Pos = gameObject.transform.position;

        if(GameObject.Find("Player").GetComponent<Player_Item>().Ring.name == "Arrow_Save")
        {
            Invoke("Instance_Self", 0.5f);
        }
    }
    void Instance_Self()
    {
        GameObject New_Bullte = Instantiate(gameObject,Pos,transform.rotation);
        New_Bullte.GetComponent<Set_Damage>().SetDamage(gameObject.GetComponent<Set_Damage>().Damage());
    }

   
}
