using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Joystick_ATK : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private RectTransform lever;
    private RectTransform rectTransform;

    [SerializeField, Range(10, 150)]
    private float leverRange;

    public static Vector2 inputDirection;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
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
        //Debug.Log("Drag");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        lever.anchoredPosition = Vector2.zero;
        inputDirection = Vector2.zero;
        GameObject.Find("Player").
        GetComponent<SkillCooldown>().Set_Drag_ATK(false);
        // Debug.Log("End");
    }

    private void ControlJoystickLever(PointerEventData eventData)
    {
        var inputPos = eventData.position - rectTransform.anchoredPosition;
        var inputVector = inputPos.magnitude < leverRange ? inputPos : inputPos.normalized * leverRange;
        lever.anchoredPosition = inputVector;
        inputDirection = inputVector / leverRange; // 이동 범위 정규화
    }
}
