using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Monster_stats : MonoBehaviour
{
    public float Hp;
    public int damage;
    public float Atk_dir;
    Drop_Item item_Drop;
    private string Drop_item_it;

    public int Monster_Drop_Tear;

    public GameObject stageManger;
    public SpriteRenderer renderer;
    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
        GameObject Player = GameObject.Find("Player");
        stageManger = GameObject.Find("StageManager");
        item_Drop = new Drop_Item();
        Hp += (Player.GetComponent<Player_Stat>().N_Stages) * 10;
        damage += Player.GetComponent<Player_Stat>().N_Stages;

    }

    void Get_damange(int damage)
    {

        Hp -= damage; //만약 방어력 추가되면 여기에 공식 추가해서 처리
        renderer.color = new Color(1, 0, 0);
        Invoke("Back", 0.1f);
        if (Hp <= 0) //체력 0 되면 사망
        {
            die();
        }
    }
    void Back()
    {
        renderer.color = new Color(1, 1, 1);
    }
    public void die()
    {
        //아이템 드롭의 수정에 따라 수정함.
        item_Drop.drop_Item(Monster_Drop_Tear,this.transform);
        stageManger.GetComponent<StageManager>().monsterdead();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player_Meele")
        {
            Get_damange(other.GetComponent<Set_Damage>().Damage());
            if (Hp <= 0)
            {
                Destroy(gameObject);
            }
        }
        if (other.gameObject.tag == "Player_ATk")
        {
            //충돌한 객체의 컴퍼넌트에서 데미지 받아옴
            Get_damange(other.GetComponent<Set_Damage>().Damage());

            if (Hp <= 0)
            {
                Destroy(gameObject);
            }
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Player_Boom")
        {
            //충돌한 객체의 컴퍼넌트에서 데미지 받아옴
            Get_damange(other.GetComponent<Set_Damage>().Damage());

            if (Hp <= 0)
            {
                Destroy(gameObject);
            }
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

    public int give_damage()
    {
        return damage;
    }
}