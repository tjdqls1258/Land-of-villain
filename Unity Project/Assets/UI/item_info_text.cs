using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class item_info_text : MonoBehaviour
{
    private Text I_info_text;
    private string i_name;
    private GameObject i_stat;

    // Start is called before the first frame update
    void Start()
    {
        I_info_text = GameObject.Find("Item_info_text").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        i_name = GameObject.Find("Player").GetComponent<item_info>().Item_name;
        i_stat = GameObject.Find(i_name);
        I_info_text.text = i_stat.GetComponent<Item_stats>().Item_Name + "\n" + "\n"
            + "reinforce.lv : " + i_stat.GetComponent<Item_stats>().Item_stat[0] + "\n"
            + "equip.hp : " + i_stat.GetComponent<Item_stats>().Item_stat[1] + "\n"
            + "equip.str : " + i_stat.GetComponent<Item_stats>().Item_stat[2] + "\n"
            + "equip.def : " + i_stat.GetComponent<Item_stats>().Item_stat[3] + "\n"
            + "equip.dex : " + i_stat.GetComponent<Item_stats>().Item_stat[4] + "\n"
            + "equip.luk : " + i_stat.GetComponent<Item_stats>().Item_stat[5];
    }
}
