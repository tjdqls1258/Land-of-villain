using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minotauros_King_Pattern : MonoBehaviour
{
    [SerializeField]
    private GameObject Minotauros_King;
    private GameObject Player;

    private float basespeed;


    // Start is called before the first frame update
    void Awake()
    {
        Player = GameObject.Find("Player");
        basespeed = this.GetComponent<Move_monster>().moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(this.transform.position, Player.transform.position) <= 1.0f)
        {
            StartCoroutine("Rush");
        }
    }

    IEnumerator Rush()
    {
        this.GetComponent<Move_monster>().moveSpeed = 0.0f;
        yield return new WaitForSeconds(0.7f);

        this.GetComponent<Move_monster>().moveSpeed = 0.003f;
        yield return new WaitForSeconds(0.1f);

        this.GetComponent<Move_monster>().moveSpeed = basespeed;
        yield return new WaitForSeconds(15.0f);
    }
}
