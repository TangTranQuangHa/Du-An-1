using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotHero : MonoBehaviour, IDropHandler
{
    [SerializeField]
    private SlotHero dragCurrent;
    public SlotHero DragCurrent
    {
        get
        {
            return dragCurrent;
        }
    }
    public event Action<SlotHero, SlotHero> OnCharacterAssigned;
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dragObject = eventData.pointerDrag;

        if (dragObject == null)
        {
            return;
        }

        SlotHero drag = dragObject.GetComponent<SlotHero>();

        if (drag == null)
        {
            return;
        }

        CharacterAssigned(drag);
    }

    private void CharacterAssigned(SlotHero drag)
    {
        if (OnCharacterAssigned != null)
        {
            OnCharacterAssigned(this, drag);
        }
    }

    public void SetCharacter(SlotHero dragCharacter)
    {
        dragCurrent = dragCharacter;
    }
}