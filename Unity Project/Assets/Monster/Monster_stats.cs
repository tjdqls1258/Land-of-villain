using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Monster_stats : MonoBehaviour
{
    public float Hp;
    public float damage;
    public float Atk_dir;
    Drop_Item item_Drop;
    private string Drop_item_it;

    public int Monster_Drop_Tear;

    private void Awake()
    {
        item_Drop = new Drop_Item();
    }

    void Get_damange(float damage)
    {
        
        Hp -= damage;
        if (Hp <= 0) //체력 0 되면 사망
        {
            die();
        }
    }
    void die()
    {
        Drop_item_it = item_Drop.drop_Item(Monster_Drop_Tear);
        GameObject item = (GameObject)Resources.Load("Item/" + Drop_item_it); 
        //리소스파일 속 item파일에 있는 Drop_item_it와 같은 이름을 가진 프리팹
        if (item != null) //있으면 소환 없으면 아무것도 안함
        {
            Instantiate(item, this.transform);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player_ATk") //플레이어(임시 스킬로 대체할 예정)와 충돌시
        {
            //충돌한 객체의 컴퍼넌트에서 데미지 받아옴
            Get_damange(other.GetComponent<Player_bullet>().Damage());
            
            if (Hp <= 0)
            {
                Destroy(gameObject);
            }
            Destroy(other.gameObject);
        }
    }

    public float give_damage()
    {
        return damage;
    }
}
