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
        // GameObject dragObject = eventData.pointerDrag;

        // if (dragObject == null)
        // {
        //     return;
        // }

        // DragHero drag = eventData.pointerDrag.GetComponent<DragHero>();
        DragHero drag = eventData.pointerDrag.GetComponent<DragHero>()
            ?? eventData.pointerDrag.GetComponentInChildren<DragHero>()
            ?? eventData.pointerDrag.GetComponentInParent<DragHero>();
        if (drag == null)
        {
            return;
        }

        //drag.transform.position = transform.position;

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