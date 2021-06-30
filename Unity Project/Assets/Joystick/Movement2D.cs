using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    public float moveSpeed;                         // 이동속도
    private Vector3 moveDirection = Vector3.zero;   // 이동방향

    private void Update()
    {
        float x = Joystick.inputDirection.x;        // 좌우 이동
        float y = Joystick.inputDirection.y;        // 상하 이동

        // 이동방향 설정
        moveDirection = new Vector3(x, y, 0);

        // 새로운 위치 = 현재 위치 + (방향 * 속도)
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -10.0f, 10.0f), Mathf.Clamp(transform.position.y, -10.0f, 10.0f), 0);
    }


}