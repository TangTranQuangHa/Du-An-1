using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragItem : CommonDrag
{
    [SerializeField] private DataItem data;

    public DataItem Data => data;

    public override void SetGhostRectTransform()
    {
        var rt = ghost.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(100, 100);

        // Anchor to middle center
        rt.anchorMin = new Vector2(0.5f, 0.5f);
        rt.anchorMax = new Vector2(0.5f, 0.5f);

        // Optional: set pivot to center as well
        rt.pivot = new Vector2(0.5f, 0.5f);

        // Reset position so it aligns correctly
        rt.anchoredPosition = Vector2.zero;
    }

    public void SetItemRectTransform()
    {
        var rt = GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(100, 100);

        // Anchor to middle center
        rt.anchorMin = new Vector2(0.5f, 0.5f);
        rt.anchorMax = new Vector2(0.5f, 0.5f);

        // Optional: set pivot to center as well
        rt.pivot = new Vector2(0.5f, 0.5f);

        // Reset position so it aligns correctly
        rt.anchoredPosition = Vector2.zero;
    }
}
