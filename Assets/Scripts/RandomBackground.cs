using UnityEngine;
using UnityEngine.UI;


public class RandomBackground : MonoBehaviour
{
    [Header("Danh sách các hình Background")]
    public Sprite[] backgroundSprites; // Mảng chứa các Sprite hình ảnh

    private Image image;

    void Start()
    {
        // Lấy Component Image gắn trên Object này
        image = GetComponent<Image>();

        // Kiểm tra xem đã gán hình vào danh sách chưa
        if (backgroundSprites.Length > 0)
        {
            // Chọn ngẫu nhiên một chỉ số từ 0 đến độ dài của mảng
            int randomIndex = Random.Range(0, backgroundSprites.Length);

            // Gán Sprite ngẫu nhiên đó cho Image
            image.sprite = backgroundSprites[randomIndex];
        }
        else
        {
            Debug.LogWarning("Chưa gán Sprite nào vào danh sách!");
        }
    }
}