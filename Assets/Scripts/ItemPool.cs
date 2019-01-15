using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemPool : MonoBehaviour, IDropHandler
{
    public void AddItem(GameObject oldItem)
    {
        if (oldItem == null)
            return;

        oldItem.transform.SetParent(transform);

        Item item = oldItem.GetComponent<ItemDisplay>().item;

        if (!Inventory.instance.HasItem(item))
            Inventory.instance.AssignItem(item);
        if (oldItem = null)
            return;
    }

    public void OnDrop (PointerEventData eventData)
    {
        if (DragHandler.objBeingDragged == null)
            return;

        DragHandler.objBeingDragged.transform.SetParent(transform);

        Item item = DragHandler.GetItemBeingDragged();

        if (!Inventory.instance.HasItem(item))
            Inventory.instance.AssignItem(item);
    }
}
