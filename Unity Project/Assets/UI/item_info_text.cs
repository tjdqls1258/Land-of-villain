using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class item_info_text : MonoBehaviour
{
    [SerializeField]
    private Text I_name_text;
    [SerializeField]
    private Text I_reinforce_text;
    [SerializeField]
    private Text I_hp_text;
    [SerializeField]
    private Text I_str_text;
    [SerializeField]
    private Text I_def_text;
    [SerializeField]
    private Text I_dex_text;
    [SerializeField]
    private Text I_luk_text;
    [SerializeField]
    private Text I_skill_name_text;
    [SerializeField]
    private Text 아이템_설명;

    private string i_name;
    private GameObject i_stat;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        i_name = GameObject.Find("Player").GetComponent<item_info>().Item_name;
        i_stat = GameObject.Find(i_name);
        if (i_stat == null)
        {
            return;
        }
        int a = i_stat.GetComponent<Item_stats>().Item_Kind;
        string Tiyp = "";
        switch (a)
        {
            case 0:
                Tiyp = "W";
                break;
            case 1:
                Tiyp = "A";
                break;
            case 2:
                Tiyp = "H";
                break;
            case 3:
                Tiyp = "S";
                break;
        }

        I_name_text.text = i_stat.GetComponent<Item_stats>().Item_Name + "(" + Tiyp+ ")";
        I_reinforce_text.text = " LV " + i_stat.GetComponent<Item_stats>().reinforce_add.ToString();
        I_hp_text.text = " + " + i_stat.GetComponent<Item_stats>().Item_stat[1].ToString() + "(+" + i_stat.GetComponent<Item_stats>().Item_stat_add[1] + ")";
        I_str_text.text = " + " + i_stat.GetComponent<Item_stats>().Item_stat[2].ToString() + "(+" + i_stat.GetComponent<Item_stats>().Item_stat_add[2] + ")";
        I_def_text.text = " + " + i_stat.GetComponent<Item_stats>().Item_stat[3].ToString() + "(+" + i_stat.GetComponent<Item_stats>().Item_stat_add[3] + ")";
        I_dex_text.text = " + " + i_stat.GetComponent<Item_stats>().Item_stat[4].ToString() + "(+" + i_stat.GetComponent<Item_stats>().Item_stat_add[4] + ")";
        I_luk_text.text = " + " + i_stat.GetComponent<Item_stats>().Item_stat[5].ToString() + "(+" + i_stat.GetComponent<Item_stats>().Item_stat_add[5] + ")";
        I_skill_name_text.text = i_stat.GetComponent<Item_stats>().item_skill_name.ToString();
        아이템_설명.text = i_stat.GetComponent<Item_stats>().스킬_설명.ToString();
    }
}
