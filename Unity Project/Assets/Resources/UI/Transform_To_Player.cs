using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transform_To_Player : MonoBehaviour
{
    GameObject Player;
    // Start is called before the first frame update
    void Awake()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Player.transform.position;
    }
}
