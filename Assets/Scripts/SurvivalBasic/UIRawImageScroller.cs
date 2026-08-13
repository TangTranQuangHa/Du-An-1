using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class UIRawImageScroller : MonoBehaviour
{
    [SerializeField] private float scrollSpeedX = 0.5f; // Tốc độ cuộn ngang
    [SerializeField] private float scrollSpeedY = 0f;   // Tốc độ cuộn dọc

    private RawImage rawImage;
    private Rect uvRect;

    private void Awake()
    {
        rawImage = GetComponent<RawImage>();
    }

    private void Update()
    {
        uvRect = rawImage.uvRect;

        // Tăng tọa độ X/Y của UV Rect theo thời gian
        uvRect.x += scrollSpeedX * Time.deltaTime;
        uvRect.y += scrollSpeedY * Time.deltaTime;

        rawImage.uvRect = uvRect;
    }
}
