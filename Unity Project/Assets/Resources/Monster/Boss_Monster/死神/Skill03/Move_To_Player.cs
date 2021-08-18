using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_To_Player : MonoBehaviour
{
    GameObject Player;
    public float moveSpeed;
    // Start is called before the first frame update
    private void Awake()
    {
        Player = GameObject.Find("Player");
    }


    // Update is called once per frame
    void Update()
    {
        if(Player != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, moveSpeed * Time.deltaTime);
        }
    }
}
