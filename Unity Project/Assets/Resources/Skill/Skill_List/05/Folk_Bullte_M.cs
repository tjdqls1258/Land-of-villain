using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Folk_Bullte_M : MonoBehaviour
{
    public GameObject Folk_Bullte;
    GameObject Player;
    float angle;
    void Awake()
    {
        StartCoroutine("BaseAttack");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator BaseAttack()
    {
        angle = Mathf.Atan2(Joystick_ATK.inputDirection.y
               , Joystick_ATK.inputDirection.x) * Mathf.Rad2Deg;
        GameObject Bullte1, Bullte2, Bullte3;
        Bullte1 = Instantiate(Folk_Bullte, transform.position, Quaternion.AngleAxis(angle - 90, Vector3.forward));
        Bullte1.GetComponent<Set_Damage>().SetDamage(GetComponent<Set_Damage>().Damage());
        yield return new WaitForSeconds(0.3f);
        Bullte2 = Instantiate(Folk_Bullte, transform.position, Quaternion.AngleAxis(angle - 90, Vector3.forward));
        Bullte2.GetComponent<Set_Damage>().SetDamage(GetComponent<Set_Damage>().Damage());
        yield return new WaitForSeconds(0.3f);
        Bullte3 = Instantiate(Folk_Bullte, transform.position, Quaternion.AngleAxis(angle - 90, Vector3.forward));
        Bullte3.GetComponent<Set_Damage>().SetDamage(GetComponent<Set_Damage>().Damage());
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }
}
