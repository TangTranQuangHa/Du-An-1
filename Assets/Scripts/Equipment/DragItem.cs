using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragItem : MonoBehaviour,
    IBeginDragHandler,
    IDragHandler,
    IEndDragHandler
{
    [SerializeField] private GameObject ghost;
    [SerializeField] private DataItem data;
    [SerializeField] private Canvas canvas;

    public DataItem Data => data;

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Tạo Ghost từ Item hiện tại
        ghost = Instantiate(gameObject);

        // Đưa Ghost lên Canvas
        ghost.transform.SetParent(canvas.transform, false);

        // Ghost không chặn Raycast
        ghost.GetComponent<Image>().raycastTarget = false;

        // Ghost đi theo chuột
        ghost.transform.position = Input.mousePosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
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