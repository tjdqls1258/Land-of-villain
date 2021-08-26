using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Monster_HP_Bar : MonoBehaviour
{
    public Image HPBar;
    public Text Hp;
    public Text Damage;
    
    // Start is called before the first frame update
    void Awake()
    {
        HPBar.fillAmount = 1f;
    }


    public void set_Text()
    {
        Hp.text = GetComponent<Monster_stats>().Hp.ToString() + "/" + GetComponent<Monster_stats>().current_HP.ToString();
    }
    public void Get_damage(float hp, float currentHP, int damage, bool Hit)
    {
        Damage.text = "-"+damage.ToString();
        if(Hit)
        {
            Damage.color = new Color(1, 0.5f, 0, 1);
            Damage.text += "!";
        }
        Hp.text = GetComponent<Monster_stats>().Hp.ToString() + "/" + GetComponent<Monster_stats>().current_HP.ToString();
        HPBar.fillAmount = hp/ currentHP;
        StartCoroutine("Damages");
    }
    IEnumerator Damages()
    {
        float time = 0;
        Vector3 pos = Vector3.zero;
        while (time < 0.2f)
        {
            Damage.rectTransform.position += new Vector3(0, 0.0001f, 0);
            pos += new Vector3(0, 0.0001f, 0);
            Damage.color += new Color(0, 0, 0, -0.01f);
            time += Time.deltaTime;
            yield return null;
        }
        Damage.text = "";
        Damage.color = new Color(1, 0, 0, 1);
        Damage.rectTransform.position -= pos;
    }
}
