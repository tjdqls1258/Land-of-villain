using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_01_Emp : MonoBehaviour
{
    void Awake()
    {
        StartCoroutine("Die");
    }

    IEnumerator Die()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        Destroy(gameObject);
    }
    
}
