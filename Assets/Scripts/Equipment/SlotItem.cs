using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotItem : MonoBehaviour, IDropHandler
{
    [SerializeField] private DragItem dragCurrent;

    public DragItem DragCurrent => dragCurrent;

    public EquipSlotType equipSlotType;

    public event Action<SlotItem, DragItem, EquipSlotType> OnItemAssigned;

    public void OnDrop(PointerEventData eventData)
    {
        DragItem drag = eventData.pointerDrag.GetComponent<DragItem>();

        if (drag == null)
            return;

        ItemAssigned(drag);
    }

    private void ItemAssigned(DragItem drag)
    {
        OnItemAssigned?.Invoke(this, drag, equipSlotType);
    }

    public void SetItem(DragItem dragItem)
    {
        dragCurrent = dragItem;
    }
}