using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void LoadScene()
    {
        var gm = GameManager.Instance;
        gm.ResetGameValues();
        gm.heroManager.GiveStarterHeroes();
        gm.Save();
        SceneManager.LoadScene("Gameplay");
    }

    public void Continue()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
}
