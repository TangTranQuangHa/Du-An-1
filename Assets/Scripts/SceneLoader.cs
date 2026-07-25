using UnityEngine;
using UnityEngine.SceneManagement; 
public class GiaoDien : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void LoadScene()
    {
        SceneManager.LoadScene("AquaArea");
    }
    public void LoadScene1()
    {
        SceneManager.LoadScene("CityArea");
    }
    public void LoadScene2()
    {
        SceneManager.LoadScene("ForestArea");
    }
    public void LoadScene3()
    {
        SceneManager.LoadScene("Recruit");
    }
    public void LoadScene5()
    {
        SceneManager.LoadScene("Heroes");
    }
    public void LoadScene4()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
