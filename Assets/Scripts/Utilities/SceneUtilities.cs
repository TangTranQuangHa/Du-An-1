using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneUtilities : MonoBehaviour
{
    public void GoToMainMenu()
    {
        var gm = GameManager.Instance;
        gm.ResetGameValues();
        gm.heroManager.GiveStarterHeroes();
        gm.Save();
        SceneManager.LoadScene("MainMenu");
    }
}
