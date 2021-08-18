using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Monster_HP_Bar : MonoBehaviour
{
    public Image HPBar;

    // Start is called before the first frame update
    void Awake()
    {
        HPBar.fillAmount = 1f;
    }

    public void Get_damage(float hp, float currentHP)
    {

        HPBar.fillAmount = hp/ currentHP;
    }
}
