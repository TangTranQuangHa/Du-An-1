using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot :
    MonoBehaviour,
    IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        var dropped = eventData.pointerDrag;
        if (transform.childCount == 0)
        {
            var item = dropped.GetComponent<InventoryItem>();
            item.parentAfterDrag = transform;
            item.transform.position = transform.position;
        }
    }
}
