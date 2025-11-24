using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public static void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public static void LoadMainMenu()
    {
        SceneManager.LoadScene("MainScene"); // Name of your main scene
    }
}