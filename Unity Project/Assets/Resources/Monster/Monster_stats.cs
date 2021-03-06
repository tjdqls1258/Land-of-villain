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
    Drop_Money Money_drop;
    private string Drop_item_it;

    public int current_HP;

    public int Monster_Drop_Tear;
    public bool IS_Boss;

    public GameObject stageManger;
    SpriteRenderer renderer;

    bool Take_Damage;

    Monster_Debuff MD = new Monster_Debuff();//몬스터 디버프를 사용하기 위함.
    private void Awake()
    {
        Take_Damage = false;
        renderer = GetComponent<SpriteRenderer>();
        GameObject Player = GameObject.Find("Player");
        stageManger = GameObject.Find("StageManager");
        item_Drop = new Drop_Item();
        Money_drop = new Drop_Money();

        if (IS_Boss)
        {
            Hp += (int)(Mathf.FloorToInt(Player.GetComponent<Player_Stat>().N_Stages/35) * Hp);
        }
        else
        {
            Hp += (int)((Player.GetComponent<Player_Stat>().N_Stages) * (Hp * 0.5f));
        }
        current_HP = Hp;
        GetComponent<Monster_HP_Bar>().set_Text();
        damage += Player.GetComponent<Player_Stat>().N_Stages;
    }

    public void Get_damange(int damage, bool NoCrit)
    {
        int Critcal = GameObject.Find("Player").GetComponent<Player_Stat>().Get_P_State(5);
        int Add_Damage = 0;
        bool Critcal_Hit = false;
        if(Critcal > Random.Range(0, 100) && (!NoCrit))
        {
            Add_Damage += (int)(GameObject.Find("Player").GetComponent<Player_Stat>().Get_P_State(2) * 0.5f);
            if(Add_Damage == 0)
            {
                Add_Damage = 1;
            }
            Critcal_Hit = true;
        }


        Hp -= (damage+ Add_Damage); //만약 방어력 추가되면 여기에 공식 추가해서 처리
        gameObject.GetComponent<Monster_HP_Bar>().Get_damage(Hp, current_HP, damage + Add_Damage, Critcal_Hit);
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
        int Rands = Random.Range(0, 100);

        item_Drop.drop_Item(Monster_Drop_Tear,this.transform);
        Money_drop.drop_Money(Monster_Drop_Tear, this.transform);
        stageManger.GetComponent<StageManager>().monsterdead();
        Destroy(gameObject);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(!Take_Damage)
        {
            if (other.gameObject.tag == "Player_Meele")
            {
                Get_damange(other.GetComponent<Set_Damage>().Damage(), false);
                
                Take_Damage = true;
                StartCoroutine("Take_Damages");
            }
            if (other.gameObject.tag == "Player_ATk")
            {
                //충돌한 객체의 컴퍼넌트에서 데미지 받아옴
                Get_damange(other.GetComponent<Set_Damage>().Damage(), false);

                
                Destroy(other.gameObject);
                Take_Damage = true;
                StartCoroutine("Take_Damages");
            }
            if (other.gameObject.tag == "Player_Boom")
            {
                //충돌한 객체의 컴퍼넌트에서 데미지 받아옴
                Get_damange(other.GetComponent<Set_Damage>().Damage(), false);

                
                Take_Damage = true;
                StartCoroutine("Take_Damages");
            }
            if (other.gameObject.tag == "Skill")
            {
                Get_damange(other.GetComponent<Skill_Danamge>().Damage(), false);
                

                Take_Damage = true;
                StartCoroutine("Take_Damages");
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!Take_Damage)
        {
            if (other.gameObject.tag == "Player_Meele")
            {
                Get_damange(other.GetComponent<Set_Damage>().Damage(), false);
                if (Hp <= 0)
                {
                    Destroy(gameObject);
                }
                Take_Damage = true;
                StartCoroutine("Take_Damages");
            }
            if (other.gameObject.tag == "Player_ATk")
            {
                //충돌한 객체의 컴퍼넌트에서 데미지 받아옴
                Get_damange(other.GetComponent<Set_Damage>().Damage(), false);

                if (Hp <= 0)
                {
                    Destroy(gameObject);
                }
                Destroy(other.gameObject);
            }
            if (other.gameObject.tag == "Player_Boom")
            {
                //충돌한 객체의 컴퍼넌트에서 데미지 받아옴
                Get_damange(other.GetComponent<Set_Damage>().Damage(), false);

                if (Hp <= 0)
                {
                    Destroy(gameObject);
                }
                Take_Damage = true;
                StartCoroutine("Take_Damages");
            }
            if (other.gameObject.tag == "Skill")
            {
                Get_damange(other.GetComponent<Skill_Danamge>().Damage(), false);
                if (Hp <= 0)
                {
                    Destroy(gameObject);
                }
                Take_Damage = true;
                StartCoroutine("Take_Damages");
            }
        }
    }
    IEnumerator Take_Damages()
    {
        yield return new WaitForSeconds(0.3f);
        Take_Damage = false;
    }

    public int give_damage()
    {
        return damage;
    }
}