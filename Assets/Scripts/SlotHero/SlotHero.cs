using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotHero : MonoBehaviour, IDropHandler
{
    [SerializeField]
    private DragHero dragCurrent;
    public DragHero DragCurrent
    {
        get
        {
            return dragCurrent;
        }
    }
    public event Action<SlotHero, DragHero> OnCharacterAssigned;
    
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop called on SlotHero");
        
        DragHero drag = eventData.pointerDrag.GetComponent<DragHero>();
        if (drag == null)
        {
            return;
        }

        CharacterAssigned(drag);
    }

    private void CharacterAssigned(DragHero drag)
    {
        if (OnCharacterAssigned != null)
        {
            OnCharacterAssigned(this, drag);
        }
    }

    public void SetCharacter(DragHero dragHero)
    {
        dragCurrent = dragHero;
    }
}