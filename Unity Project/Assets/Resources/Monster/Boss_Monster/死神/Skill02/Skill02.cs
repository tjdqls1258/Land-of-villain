using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill02 : MonoBehaviour
{
    float Distance;
    Vector2 Target_Vec;
    public SpriteRenderer renderer;
    public Sprite ATK_Image;
    void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
        GameObject Player = GameObject.Find("Player");
        Target_Vec = Player.transform.position;
        Distance = Vector3.Distance(transform.position, Player.transform.position);
        transform.position -= new Vector3(0, 0.2f,0);
        Vector2 vec = new Vector2(Player.transform.position.x - transform.position.x,
            Player.transform.position.y - transform.position.y);

        float angle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
        Quaternion angleAxis = Quaternion.AngleAxis(angle - 90f, Vector3.forward);

        transform.rotation = angleAxis;

        StartCoroutine("Do_It");

    }
    IEnumerator Do_It()
    {
        while (Distance + 1.0f > gameObject.transform.localScale.y)
        {
            gameObject.transform.localScale += new Vector3(0,0.01f,0.0f);
            yield return null;
        }
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        renderer.sprite = ATK_Image;
        GameObject.Find("死神(Clone)").transform.position = Target_Vec;
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);

    }
}
