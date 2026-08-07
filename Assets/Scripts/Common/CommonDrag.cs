using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class CommonDrag :
    MonoBehaviour,
    IBeginDragHandler,
    IDragHandler,
    IEndDragHandler
{
    protected GameObject ghost;
    [SerializeField] private Canvas canvas;

    private void Awake()
    {
        canvas = transform.root.GetComponent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Tạo Ghost từ Item hiện tại
        ghost = Instantiate(gameObject, canvas.transform);

        // Đưa Ghost lên Canvas
        // ghost.transform.SetParent(canvas.transform, false);
        ghost.transform.SetAsLastSibling();

        // Ghost không chặn Raycast
        ghost.GetComponent<Image>().raycastTarget = false;

        ghost.transform.localScale = Vector3.one;

        SetGhostRectTransform();
    }

    public abstract void SetGhostRectTransform();

    public void OnDrag(PointerEventData eventData)
    {
        if (ghost == null) return;
        // Ghost đi theo chuột
        ghost.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Xóa Ghost
        Destroy(ghost);
        ghost = null;
    }
}
