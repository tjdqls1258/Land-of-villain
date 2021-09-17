using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stille_HP : MonoBehaviour
{
    GameObject Player;
    int N_HP;
    public int MAX_healing;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Monster")
        {
            Player = GameObject.Find("Player");
            N_HP = Player.GetComponent<Player_Stat>().Get_P_State(1);
            if (Player.GetComponent<Player_Item>().Ring != null)
            {
                string PlayerRing = Player.GetComponent<Player_Item>().Ring.GetComponent<Item_stats>().Get_Item_Name();
                if (PlayerRing == "Blood Ring")
                {
                    set_Max_healing(4);
                }
            }
            int Healing = Random.Range(0, MAX_healing);
            if (N_HP + Healing > Player.GetComponent<Player_Stat>().Get_P_State(0))
            {
                Player.GetComponent<Player_Stat>().Set_P_State(
                    1, Player.GetComponent<Player_Stat>().Get_P_State(0));
            }
            else
            {
                Player.GetComponent<Player_Stat>().Set_P_State(1, N_HP + Healing);
            }
            Destroy(gameObject);
        }
    }
    public void set_Max_healing(int healing)
    {
        this.MAX_healing = healing;
    }
}
