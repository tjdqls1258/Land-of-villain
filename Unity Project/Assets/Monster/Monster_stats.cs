using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_stats : MonoBehaviour
{
    public int Hp;
    public int damage;
    public float Atk_dir;

    public void Hit_monster(float dam)
    {
        Get_damange(dam);
    }

    void Get_damange(int damage)
    {
        Hp -= damage;
        if (Hp <= 0) //체력 0 되면 사망
        {
            //die();
        }
    }
    void die()
    {
        //Instantiate(item, tran.position); //아이템 생성
        StopCoroutine("Fire");
        Destroy(gameObject);

    }
    public float give_damage()
    {
        return damage;
    }
}
