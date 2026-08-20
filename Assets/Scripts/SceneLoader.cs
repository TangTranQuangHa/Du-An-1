using UnityEngine;
using UnityEngine.SceneManagement; 
public class GiaoDien : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void LoadSceneAquaArea()
    {
        SceneManager.LoadScene("AquaArea");
    }
    public void LoadSceneCityArea()
    {
        SceneManager.LoadScene("CityArea");
    }
    public void LoadSceneForestArea()
    {
        SceneManager.LoadScene("ForestArea");
    }
    public void LoadSceneRecruit()
    {
        SceneManager.LoadScene("Recruit");
    }
    public void LoadSceneHeroes()
    {
        SceneManager.LoadScene("Heroes");
    }
    public void LoadSceneMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadSceneGameplay()
    {
        SceneManager.LoadScene("Gameplay");
    }
    public void LoadSceneGameVictory()
    {
        SceneManager.LoadScene("GameVictory");
    }
}
