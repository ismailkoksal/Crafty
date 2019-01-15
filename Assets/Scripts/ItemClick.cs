using UnityEngine;
using UnityEngine.EventSystems;

public class ItemClick : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Inventory.instance.ReturnItem(gameObject);
    }
}