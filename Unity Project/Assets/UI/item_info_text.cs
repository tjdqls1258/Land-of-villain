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
        I_name_text.text = i_stat.GetComponent<Item_stats>().Item_Name;
        I_reinforce_text.text = " LV " + i_stat.GetComponent<Item_stats>().reinforce_add.ToString();
        I_hp_text.text = " + " + i_stat.GetComponent<Item_stats>().Item_stat[1].ToString();
        I_str_text.text = " + " + i_stat.GetComponent<Item_stats>().Item_stat[2].ToString();
        I_def_text.text = " + " + i_stat.GetComponent<Item_stats>().Item_stat[3].ToString();
        I_dex_text.text = " + " + i_stat.GetComponent<Item_stats>().Item_stat[4].ToString();
        I_luk_text.text = " + " + i_stat.GetComponent<Item_stats>().Item_stat[5].ToString();
        I_skill_name_text.text = i_stat.GetComponent<Item_stats>().item_skill_name.ToString();
    }
}
