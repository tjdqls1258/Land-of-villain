using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen_Bee_Paten01 : MonoBehaviour
{
    Vector3 StartPoint;
    GameObject Player;
    Quaternion angleAxis;
    public GameObject Bullte;

    // Start is called before the first frame update
    void Awake()
    {
        StartPoint = transform.position; //시작지점
        Find_Player();
        GameObject Bulltes = Instantiate(Bullte, transform.position, angleAxis);
        Bullte.GetComponent<Skill_damage>().Set_Damage(GetComponent<Skill_damage>().Damage());

    }


    void Find_Player()
    {
        Player = GameObject.Find("Player");
        Vector2 vec = Vector2.zero;//초기화
        if (Player == null)
        {
            return;
        }
        if (transform != null)
        {
            vec = new Vector2(Player.transform.position.x - transform.position.x,
                Player.transform.position.y - transform.position.y);
            //트렌스폼 찾으면 플레이어를 바라보는 벡터구함.
        }

        float angle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg; //y와 x의 좌표를 탄젠트해서 각도를 구함
        angleAxis = Quaternion.AngleAxis(angle - 90f, Vector3.forward); //회전할 Z축 각도 저장
    }
}
