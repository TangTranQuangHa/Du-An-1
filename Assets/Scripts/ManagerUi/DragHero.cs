using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragHero : CommonDrag
{
    public override void SetGhostRectTransform()
    {
        var rt = ghost.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(150, 130);

        // Anchor to middle center
        rt.anchorMin = new Vector2(0.5f, 0.5f);
        rt.anchorMax = new Vector2(0.5f, 0.5f);

        // Optional: set pivot to center as well
        rt.pivot = new Vector2(0.5f, 0.5f);

        // Reset position so it aligns correctly
        rt.anchoredPosition = Vector2.zero;

        // Scale the ghost to match the original size
        rt.localScale = new Vector3(1.8f, 2.5f, 1);
    }
}
