using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMG_Skill : MonoBehaviour, Skill
{
    public GameObject Mod1;
    public GameObject Mod2;
    public GameObject Mod3;

    GameObject Player;

    int Mod = 0;

    int ATK_Damage;
    float ATK_Speed;


    public void Skill_Action()
    {
        Player = GameObject.Find("Player");

        switch (Mod)
        {
            case 1://초기화
                Player.GetComponent<Player_Item>().Weapon.GetComponent<Item_stats>().Bullte = Mod1;
                Mod3_State_End();
                break;
            case 2://3연발
                Player.GetComponent<Player_Item>().Weapon.GetComponent<Item_stats>().Bullte = Mod2;
                Mod2_State();
                break;
            case 3://연사 (데미지 감소)
                Player.GetComponent<Player_Item>().Weapon.GetComponent<Item_stats>().Bullte = Mod3;
                Mod2_State_End();
                Mod3_State();
                break;
            default:
                break;
        }
        Mod++;
        if(Mod >= 3)
        {
            Mod = 1;
        }

    }

    public void Passive()
    {
        Player = GameObject.Find("Player");
        ATK_Damage = Player.GetComponent<Player_Item>().Weapon.GetComponent<Item_stats>().Item_stat[2];
        ATK_Speed = Player.GetComponent<Player_Item>().Weapon.GetComponent<Item_stats>().ATK_Speed;
        Mod = 1;
    }
    //중지시키는 함수
    public void Stop_Passive()
    {
    }

    public void Mod2_State()
    {
        //공속 느려짐 데미지 0.5배
        Player.GetComponent<Player_Item>().Weapon.GetComponent<Item_stats>().Item_stat[2] =
            (int)(Player.GetComponent<Player_Item>().Weapon.GetComponent<Item_stats>().Item_stat[2] * 0.7f);
        Player.GetComponent<Player_Item>().Weapon.GetComponent<Item_stats>().ATK_Speed = 0.7f;
    }
    public void Mod3_State()
    {
        //공속 개빨라짐, 데미지 0.3배
        Player.GetComponent<Player_Item>().Weapon.GetComponent<Item_stats>().ATK_Speed = 0.05f;
        Player.GetComponent<Player_Item>().Weapon.GetComponent<Item_stats>().Item_stat[2] =
            (int)(Player.GetComponent<Player_Item>().Weapon.GetComponent<Item_stats>().Item_stat[2] * 0.1f);
    }
    public void Mod2_State_End()
    {
        Player.GetComponent<Player_Item>().Weapon.GetComponent<Item_stats>().ATK_Speed = ATK_Speed;
        Player.GetComponent<Player_Item>().Weapon.GetComponent<Item_stats>().Item_stat[2] = ATK_Damage;
    }
    public void Mod3_State_End()
    {
        Player.GetComponent<Player_Item>().Weapon.GetComponent<Item_stats>().Item_stat[2] = ATK_Damage;
        Player.GetComponent<Player_Item>().Weapon.GetComponent<Item_stats>().ATK_Speed = ATK_Speed;
    }

}
