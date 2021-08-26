using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item_info : MonoBehaviour
{
    [SerializeField] private GameObject Item_info;
    public string Item_name;

    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Item")
        {
            Item_info.SetActive(true);
            Item_name = other.gameObject.name;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Item")
        {
            Item_info.SetActive(false);
        }
    }
    public void item_info_Set(bool a)
    {
        Item_info.SetActive(a);
    }
}
