using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minotauros_King_Pattern : MonoBehaviour
{
    [SerializeField]
    private GameObject Minotauros_King;
    private GameObject Player;
    private Vector3 Rush_Target;
    private bool rushcool = false;

    private float basespeed;


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        basespeed = this.GetComponent<Move_monster>().moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if((Vector3.Distance(this.transform.position, Player.transform.position) <= 1.0f) && (rushcool == false))
        {
            StartCoroutine("Rush");
        }
    }

    IEnumerator Rush()
    {
        rushcool = true;
        this.GetComponent<Move_monster>().moveSpeed = 0.0f;
        Rush_Target = Player.transform.position;
        yield return new WaitForSeconds(0.7f);

        this.GetComponent<Move_monster>().enabled = false;
        while (this.transform.position != Rush_Target)
        {
            yield return null;
            transform.position = Vector3.MoveTowards(this.transform.position, Rush_Target, ((basespeed * 3)));
        }
        yield return new WaitForSeconds(0.1f);

        this.GetComponent<Move_monster>().enabled = true ;
        this.GetComponent<Move_monster>().moveSpeed = basespeed;
        yield return new WaitForSeconds(10.0f);

        rushcool = false;
    }
}
