using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Joystick_ATK : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private RectTransform lever;
    private RectTransform rectTransform;

    public static Vector2 inputDirection;

    float Back_Radius;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        Back_Radius = rectTransform.rect.width * 0.5f;
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        ControlJoystickLever(eventData);
        // Debug.Log("Begin");
    }

    public void OnDrag(PointerEventData eventData)
    {
        ControlJoystickLever(eventData);
        GameObject.Find("Player").
        GetComponent<SkillCooldown>().Set_Drag_ATK(true);
        GameObject.Find("Player").GetComponent<Player_Stat>().Reset_Speed();

        //Debug.Log("Drag");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        lever.anchoredPosition = Vector2.zero;
        inputDirection = Vector2.zero;
        GameObject.Find("Player").
        GetComponent<SkillCooldown>().Set_Drag_ATK(false);
        GameObject.Find("Player").GetComponent<Player_Stat>().Reset_Speed();
        // Debug.Log("End");
    }

    private void ControlJoystickLever(PointerEventData eventData)
    {
        Vector2 inputPos = new Vector2(eventData.position.x - rectTransform.position.x, 
            eventData.position.y - rectTransform.position.y);
        inputPos = Vector2.ClampMagnitude(inputPos, Back_Radius);

        Debug.Log(eventData.position);

        float FSpr = (rectTransform.position - lever.position).sqrMagnitude / (Back_Radius * Back_Radius);

        Vector2 vecNormal = inputPos.normalized;

      
        lever.anchoredPosition = inputPos;
        inputDirection = inputPos / FSpr; // 이동 범위 정규화
    }
}
