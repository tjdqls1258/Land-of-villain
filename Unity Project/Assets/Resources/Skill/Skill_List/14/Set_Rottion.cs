using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set_Rottion : MonoBehaviour
{
    GameObject Player;
    public float Rotate_Speed;
    // Start is called before the first frame update
    void Awake()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Player.transform.position;
        this.transform.Rotate(new Vector3(0, 0, Rotate_Speed));
    }
}
