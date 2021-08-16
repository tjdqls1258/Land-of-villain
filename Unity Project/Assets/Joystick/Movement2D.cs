using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement2D : MonoBehaviour
{
    public float moveSpeed;                         // 이동속도
    private Vector3 moveDirection = Vector3.zero; // 이동방향
    Animator animator;
    SpriteRenderer rend;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        float x = Joystick.inputDirection.x;        // 좌우 이동
        float y = Joystick.inputDirection.y;        // 상하 이동

        // 이동방향 설정
        moveDirection = new Vector3(x, y, 0);
        
        if(x>0 )
        {
            animator.SetBool("LR", true);
            animator.SetBool("Back", false);
            animator.SetBool("Walk", false);
            Debug.Log("오른쪽으로 이동");
            rend.flipX = false;
            if (y < -0.4)
            {
                animator.SetBool("Walk", true);
                animator.SetBool("Back", false);
                animator.SetBool("LR", false);
                Debug.Log("위로 이동");

            }
            else if (y > 0.4)
            {
                animator.SetBool("Back", true);
                animator.SetBool("LR", false);
                animator.SetBool("Walk", false);
                Debug.Log("아래로 이동");
            }
            
        }
        if(x < 0)
        {
            animator.SetBool("LR", true);
            animator.SetBool("Back", false);
            animator.SetBool("Walk", false);
            rend.flipX = true;
            if (y < -0.4)
            {
                animator.SetBool("Walk", true);
                animator.SetBool("Back", false);
                animator.SetBool("LR", false);

                Debug.Log("위로 이동");

            }
            else if (y > 0.4)
            {
                animator.SetBool("Back", true);
                animator.SetBool("LR", false);
                animator.SetBool("Walk", false);
                Debug.Log("아래로 이동");
            }
            Debug.Log("왼쪽으로 이동");
        }
        if((x==0) &&(y==0))
        {
            animator.SetBool("Back", false);
            animator.SetBool("LR", false);
            animator.SetBool("Walk", false);
        }
        if(GetComponent<SkillCooldown>().dashactive)
        {
            animator.SetBool("Dash", true);
        }
        if (!GetComponent<SkillCooldown>().dashactive)
        {
            animator.SetBool("Dash", false);
        }
        // 새로운 위치 = 현재 위치 + (방향 * 속도)
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -10.0f, 10.0f), Mathf.Clamp(transform.position.y, -10.0f, 10.0f), 0);
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        transform.position = new Vector3(0, 0, 0);
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}