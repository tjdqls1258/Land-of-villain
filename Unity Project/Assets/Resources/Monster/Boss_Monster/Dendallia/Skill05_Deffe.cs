using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill05_Deffe : MonoBehaviour
{
    float First_Speed;
    float time;
    GameObject Dendallias;
    private void Awake()
    {
        Dendallias = GameObject.Find("Dendallia(Clone)");
        GameObject Player = GameObject.Find("Player");
        First_Speed = Player.GetComponent<Movement2D>().moveSpeed;
        time = 0;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(time >= 2.0f)
            {
                collision.gameObject.GetComponent<Movement2D>().moveSpeed = 0f;
                collision.gameObject.GetComponent<SkillCooldown>().Don_Restart = true;
                Invoke("EndDeffue", 2.0f);
            }
            else 
            {
                time += Time.deltaTime;
                collision.gameObject.GetComponent<Movement2D>().moveSpeed = First_Speed * 0.5f;
                collision.gameObject.GetComponent<SkillCooldown>().Don_Restart = true;
            }
        }
    }
    private void Update()
    {
        if(Dendallias == null)
        {
            Destroy(gameObject);
        }
    }
    void EndDeffue()
    {
        GameObject Player = GameObject.Find("Player");
        Player.GetComponent<Movement2D>().moveSpeed = First_Speed;
        time = 0;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            time = 0;
            collision.gameObject.GetComponent<Movement2D>().moveSpeed = First_Speed;
            collision.gameObject.GetComponent<SkillCooldown>().Don_Restart = false;
        }
    }
}
