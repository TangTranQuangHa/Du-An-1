using UnityEngine;

public class ManagerSlotBattle : MonoBehaviour
{
    [SerializeField] private SlotHero[] slotHeroes;
    private void OnEnable()
    {
        foreach(SlotHero member in slotHeroes)
        {
            member.OnCharacterAssigned += UpdateSlotHero;
        }
    }
    private void OnDisable()
    {
        foreach(SlotHero member in slotHeroes)
        {
            // Subscribe to the OnCharacterAssigned event of slotHero
            member.OnCharacterAssigned -= UpdateSlotHero;
        }
    }
    public void UpdateSlotHero(SlotHero slotHero, DragHero dragHero)
    {
        // check if there is an existing hero in the slot, then move it back to the scroll view
        if (slotHero.DragCurrent != null)
        {
            MoveTheDragged(slotHero.DragCurrent, dragHero.transform.parent);
        }
        // set the new hero to the slot
        MoveTheDragged(dragHero, slotHero.transform);
        RemoveDuplicateHero(slotHero, dragHero);
        dragHero.SetHeroRectTransform();
        slotHero.SetCharacter(dragHero);
    }
    private void MoveTheDragged(CommonDrag drag, Transform parent)
    {
        Transform frame = drag.transform;

        frame.SetParent(parent);
        frame.localPosition = Vector3.zero;
    }
    private void RemoveDuplicateHero(SlotHero slotHero, DragHero dragHero)
    {
        foreach(SlotHero member in slotHeroes)
        {
            if (dragHero == member.DragCurrent && member != slotHero)
                member.SetCharacter(null);
        }
    }
}
