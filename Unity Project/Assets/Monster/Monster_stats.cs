using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Monster_stats : MonoBehaviour
{
    public int Hp;
    public int damage;
    public float Atk_dir;
    Drop_Item item_Drop;
    private string Drop_item_it;

    public int Monster_Drop_Tear;

    public GameObject stageManger;

    private void Awake()
    {
        stageManger = GameObject.Find("StageManager");
        item_Drop = new Drop_Item();

    }

    void Get_damange(int damage)
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
        //GameObject item = (GameObject)Resources.Load("Item/Copper_Sword", typeof(GameObject));
        //리소스파일 속 item파일에 있는 Drop_item_it와 같은 이름을 가진 프리팹
        if (item != null) //있으면 소환 없으면 아무것도 안함
        {
            Instantiate(item, this.transform.position, Quaternion.identity); 
        }
        stageManger.GetComponent<StageManager>().monsterdead();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player_Meele")
        {
            Get_damange(other.GetComponent<Player_Status>().Damage());

            if (Hp <= 0)
            {
                Destroy(gameObject);
            }
        }
        if (other.gameObject.tag == "Player_ATk")
        {
            //충돌한 객체의 컴퍼넌트에서 데미지 받아옴
            Get_damange(other.GetComponent<Player_bullet>().Damage());

            if (Hp <= 0)
            {
                Destroy(gameObject);
            }
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Skill")
        {
            Get_damange(other.GetComponent<Skill_Danamge>().Damage());
            if (Hp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    public float give_damage()
    {
        return damage;
    }
}