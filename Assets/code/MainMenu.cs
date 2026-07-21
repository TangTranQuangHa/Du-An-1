using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene("gameplay");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    
}
