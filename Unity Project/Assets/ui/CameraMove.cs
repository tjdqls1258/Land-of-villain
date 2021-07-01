using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject Player;
    public Vector3 lookoffset = new Vector3(0, 0, -10);

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Player.transform.position + lookoffset;        
    }
}
