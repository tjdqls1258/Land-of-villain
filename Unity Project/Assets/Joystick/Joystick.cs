using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private RectTransform lever;
    private RectTransform rectTransform;

    [SerializeField, Range(10, 150)]
    private float leverRange;


    public Camera Camera;
    Vector2 mousepos;
    Vector2 First_Pos;

    float Back_Radius;

    public static Vector2 inputDirection;
    private void Awake()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
        First_Pos = rectTransform.position;

        Back_Radius = rectTransform.rect.width * 0.5f;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && (Input.mousePosition.x < 600) && (Input.mousePosition.y < 340))
        {
            mousepos = Input.mousePosition;
            // = Camera.ScreenToWorldPoint(mousepos);
            rectTransform.position = mousepos;
            Debug.Log(mousepos);
        }
    }

   

    public void OnBeginDrag(PointerEventData eventData)
    {
        ControlJoystickLever(eventData);
        GameObject.Find("Player").GetComponent<Player_Stat>().Reset_Speed();
        // Debug.Log("Begin");
    }

    public void OnDrag(PointerEventData eventData)
    {
        ControlJoystickLever(eventData);
        // Debug.Log("Drag");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        lever.anchoredPosition = Vector2.zero;
        inputDirection = Vector2.zero;
        rectTransform.position = First_Pos;
        // Debug.Log("End");
    }

    private void ControlJoystickLever(PointerEventData eventData)
    {
        //var inputPos = eventData.position - rectTransform.anchoredPosition;
        //var inputVector = inputPos.magnitude < leverRange ? inputPos : inputPos.normalized * leverRange;
        //lever.anchoredPosition = inputVector;
        //inputDirection = inputVector / leverRange; // 이동 범위 정규화

        Vector2 inputPos = new Vector2(eventData.position.x - rectTransform.position.x,
            eventData.position.y - rectTransform.position.y);
        inputPos = Vector2.ClampMagnitude(inputPos, Back_Radius);

        Debug.Log(eventData.position);

        float FSpr = (rectTransform.position - lever.position).sqrMagnitude / (Back_Radius * Back_Radius);

        Vector2 vecNormal = inputPos.normalized;



        //var inputVector = inputPos.magnitude < leverRange ? inputPos : inputPos.normalized * leverRange;
        lever.anchoredPosition = inputPos;
        inputDirection = (inputPos / FSpr).normalized; // 이동 범위 정규화
    }
}