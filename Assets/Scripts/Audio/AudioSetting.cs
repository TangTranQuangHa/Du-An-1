using UnityEngine;

public class AudioSetting : MonoBehaviour
{
    public void OpenSetting()
    {
        Time.timeScale = 0;
    }
    public void CloseSetting()
    {
        Time.timeScale = 1;
    }
}
