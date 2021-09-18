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
        Mod++;
        if (Mod > 3)
        {
            Mod = 1;
        }
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
        

    }

    public void Passive()
    {
        Player = GameObject.Find("Player");
        Player.GetComponent<Player_Item>().Weapon.GetComponent<Item_stats>().ATK_Speed = 0.3f;
        Mod1.GetComponent<Set_Damage>().데미지_비율 = 1f;
        Mod2.GetComponent<Set_Damage>().데미지_비율 = 1f;
        Mod3.GetComponent<Set_Damage>().데미지_비율 = 1f;
        ATK_Speed = Player.GetComponent<Player_Item>().Weapon.GetComponent<Item_stats>().ATK_Speed;
        ATK_Damage = Player.GetComponent<Player_Stat>().Get_P_State(5);
        Player.GetComponent<Player_Stat>().Set_P_State(5, ATK_Damage + 30);
        Mod = 1;
    }
    //중지시키는 함수
    public void Stop_Passive()
    {
        Player.GetComponent<Player_Item>().Weapon.GetComponent<Item_stats>().ATK_Speed = 0.3f;
        Mod1.GetComponent<Set_Damage>().데미지_비율 = 1f;
        Mod2.GetComponent<Set_Damage>().데미지_비율 = 1f;
        Mod3.GetComponent<Set_Damage>().데미지_비율 = 1f;
        Player.GetComponent<Player_Stat>().Set_P_State(5, ATK_Damage);
    }

    public void Mod2_State()
    {
        Mod2.GetComponent<Set_Damage>().데미지_비율 = 0.4f;
        Player.GetComponent<Player_Item>().Weapon.GetComponent<Item_stats>().ATK_Speed = 0.5f;
        Player.GetComponent<Player_Stat>().Set_P_State(5, ATK_Damage);
    }
    public void Mod3_State()
    {
        Mod3.GetComponent<Set_Damage>().데미지_비율 = 0.2f;
        Player.GetComponent<Player_Item>().Weapon.GetComponent<Item_stats>().ATK_Speed = 0.1f;
        Player.GetComponent<Player_Stat>().Set_P_State(5, 0);
    }
    public void Mod2_State_End()
    {
        Mod2.GetComponent<Set_Damage>().데미지_비율 = 1.0f;
        Player.GetComponent<Player_Item>().Weapon.GetComponent<Item_stats>().ATK_Speed = ATK_Speed;
    }
    public void Mod3_State_End()
    {
        Player.GetComponent<Player_Item>().Weapon.GetComponent<Item_stats>().ATK_Speed = ATK_Speed;
        Mod3.GetComponent<Set_Damage>().데미지_비율 = 1f;
        Player.GetComponent<Player_Stat>().Set_P_State(5, ATK_Damage + 30);
    }

}
