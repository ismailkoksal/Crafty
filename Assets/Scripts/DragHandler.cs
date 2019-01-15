using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject objBeingDragged;
    public static Item GetItemBeingDragged()
    {
        return objBeingDragged.GetComponent<ItemDisplay>().item;
    }

    Vector3 startPosition; 
    Transform startParent;

    Transform itemDraggerParent;
    CanvasGroup canvasGroup;

    public void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        itemDraggerParent = GameObject.FindGameObjectWithTag("ItemDraggerParent").transform;
    }

    public void OnBeginDrag(PointerEventData eventDada)
    {
        // TODO : Play audio
        objBeingDragged = gameObject;
        startPosition = transform.position;
        startParent = transform.parent;

        transform.SetParent(itemDraggerParent);

        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // TODO 2 : Play audio
        objBeingDragged = null;
        canvasGroup.blocksRaycasts = true;

        if (transform.parent == itemDraggerParent)
        {
            transform.position = startPosition;
            transform.SetParent(startParent);
        }
    }
}
