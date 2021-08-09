using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen_Bee_Paten02 : MonoBehaviour
{

    GameObject Player;
    public GameObject Bullte;
    Quaternion angleAxis;
    int Damage_s;
    
    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine("ATK_5");
    }
    IEnumerator ATK_5()
    {
        for (int i = 0; i < 5; i++)
        {
            Find_Player();
            GameObject Bulltes = Instantiate(Bullte, transform.position, angleAxis);
            Bullte.GetComponent<Monster_Bullet>().Set_Damage(GetComponent<Skill_damage>().Damage());
            yield return new WaitForSeconds(.2f);
        }
        Destroy(gameObject);
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
        //회전 속도
    }
    public void Set_Damage(int dam)
    {
        this.Damage_s = dam;
    }
}
