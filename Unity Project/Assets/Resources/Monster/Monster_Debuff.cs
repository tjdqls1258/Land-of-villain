using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Debuff : MonoBehaviour
{
    //몬스터에 피해를 주기 위해 GetComponent로 몬스터의 정보를 가져옴.
    private Monster_stats MS;
    //독 상태의 변수가 0 이상일 경우 독공력 활성화
    int Poison = 0;
    int Damage;
    public GameObject Deffue_Image;
    // Start is called before the first frame update
    void Start()
    {   
        MS=GetComponent<Monster_stats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Poison_Debuff(int Damage)
    {   //앞에 stop을 먼저 한 이유는 독의 쿨타임이 0 보다 큰 상태로 독상태에 다시 걸렸을 때 중첩을 피하기 위함.
        this.Damage = Damage;
        StopCoroutine("Poison_D");
        StartCoroutine("Poison_D");
        GameObject Deffu = Instantiate(Deffue_Image, transform.position, Quaternion.identity);
        Deffu.GetComponent<Deffue_Monster>().transform_move(gameObject);
    }

    IEnumerator Poison_D()
    {
        Poison = 5;
        while (Poison >= 0)
        {
            yield return new WaitForSeconds(0.5f);
            MS.Get_damange(Damage, true);
            Poison--;
        }
    }

}
