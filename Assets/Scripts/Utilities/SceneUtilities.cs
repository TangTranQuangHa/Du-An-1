using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneUtilities : MonoBehaviour
{
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
