using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragHero : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] GameObject ghost;
    [SerializeField] Canvas canvas;
    private void Awake()
    {
        if (canvas == null)
            Debug.LogWarning("canvas doesn't exit");
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (ghost != null) return;
        ghost = Instantiate(gameObject);
        ghost.transform.SetParent(canvas.transform);
        ghost.GetComponent<Image>().raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        ghost.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Destroy(ghost);
    }
}