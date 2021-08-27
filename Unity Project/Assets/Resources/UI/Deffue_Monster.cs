using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deffue_Monster : MonoBehaviour
{
    GameObject Target;
    public void transform_move(GameObject Monster)
    {
        Target = Monster;
    }
    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.identity;
        if(Target != null)
        {
            transform.position = Target.transform.position;
        }
        if(Target == null)
        {
            Destroy(gameObject);
        }
    }
}
