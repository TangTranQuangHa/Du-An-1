#nullable enable
using System.IO;
using UnityEngine;
using UnityEditor;

public static class SaveSystem
{
    const string SAVE_DATA_FILE = "/savaData.json";

    // Hàm Save Game
    public static void Save(SaveData saveData)
    {        
        // Chuyển đổi dữ liệu sang định dạng JSON
        string json = JsonUtility.ToJson(saveData);
        
        // Đường dẫn lưu file an toàn trên mọi thiết bị (PC, Android, iOS...)
        string path = Application.persistentDataPath + SAVE_DATA_FILE;
        
        // Ghi chuỗi JSON vào file
        File.WriteAllText(path, json);
        Debug.Log("Đã lưu game tại: " + path);
    }

    // Hàm Load Game
    public static SaveData? Load()
    {
        // Đường dẫn lưu file an toàn trên mọi thiết bị (PC, Android, iOS...)
        string path = Application.persistentDataPath + SAVE_DATA_FILE;
        
        if (File.Exists(path))
        {
            // Đọc chuỗi JSON từ file
            string json = File.ReadAllText(path);
            
            // Chuyển ngược JSON thành đối tượng
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            return data;
        }
        else
        {
            Debug.LogWarning("Không tìm thấy file save tại: " + path);
            return null;
        }
    }
}
