using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minotauros_King_Pattern : MonoBehaviour
{
    [SerializeField]
    private GameObject Minotauros_King;
    private GameObject Player;
    [SerializeField]
    private GameObject mino_normal;
    private Vector3 Rush_Target;
    private bool rushcool = false;
    private GameObject stagemanager;

    private float basespeed;

    private List<GameObject> Monster = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        basespeed = this.GetComponent<Move_Monster_2>().moveSpeed;
        stagemanager = GameObject.Find("StageManager");
    }

    // Update is called once per frame
    void Update()
    {
        if((Vector3.Distance(this.transform.position, Player.transform.position) <= 1.5f) && (rushcool == false))
        {
            StartCoroutine("Rush");
        }
    }

    IEnumerator Rush()
    {
        rushcool = true;
        this.GetComponent<Move_Monster_2>().moveSpeed = 0.0f;
        Rush_Target = (Player.transform.position - transform.position).normalized;
        float Distances = Vector2.Distance(transform.position, Player.transform.position);

        yield return new WaitForSeconds(0.53f);
        float time = 0; 
        this.GetComponent<Move_Monster_2>().enabled = false;
        while (Distances * 1.2 >= time)
        {
            yield return null;
            time += Time.deltaTime;
            //transform.position = Vector3.MoveTowards(this.transform.position, Rush_Target, ((basespeed * 5 * Time.deltaTime)));
            transform.position += Rush_Target * 3.0f * Time.deltaTime;
        }
        yield return new WaitForSeconds(0.1f);

        for (int i = 0; i < 3; i++)
        {
            Spawn_mino_normal();
        }
        stagemanager.GetComponent<StageManager>().Monster_Check();
        yield return new WaitForSeconds(0.05f);

        this.GetComponent<Move_Monster_2>().enabled = true ;
        this.GetComponent<Move_Monster_2>().moveSpeed = basespeed;
        yield return new WaitForSeconds(10.0f);

        rushcool = false;
    }

    private void Spawn_mino_normal()
    {
        Vector3 spawnPos = GetRandomPosition();

        GameObject instance = Instantiate(mino_normal, spawnPos, Quaternion.identity);
        Monster.Add(instance);
    }

    private Vector3 GetRandomPosition()
    {
        int a = Random.Range(0, 3);
        Vector3 basePosition = this.transform.position;

        float PosX = basePosition.x + Random.Range(-3, 3);
        float PosY = basePosition.y + Random.Range(-3, 3);

        if (PosX < 0)
        {
            PosX -= 0.5f;
        }
        else
        {
            PosX += 0.5f;
        }

        if (PosY < 0)
        {
            PosY -= 0.5f;
        }
        else
        {
            PosY += 0.5f;
        }
        if (PosX < -9.5f)
        {
            PosX = -9.5f;
        }
        if (PosX > 9.5f)
        {
            PosX = 9.5f;
        }
        if (PosY < -9.5f)
        {
            PosY = -9.5f;
        }
        if (PosY > 9.5f)
        {
            PosY = 9.5f;
        }
        Vector3 spawnPos = new Vector3(PosX, PosY, 0f);

        return spawnPos;
    }
}
