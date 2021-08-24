using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Move_Joy : MonoBehaviour, IBeginDragHandler
{
    public RectTransform rectTransform;
    public void OnBeginDrag(PointerEventData eventData)
    {
        rectTransform.position = eventData.position;
        // Debug.Log("Begin");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
