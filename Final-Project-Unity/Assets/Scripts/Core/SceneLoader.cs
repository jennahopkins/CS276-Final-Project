using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public static void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
        AudioManager.Instance.PlayMusic(AudioManager.Instance.levelMusic);
    }

    public static void LoadMainMenu()
    {
        SceneManager.LoadScene("MainScene"); // Name of your main scene
        AudioManager.Instance.PlayMusic(AudioManager.Instance.menuMusic);
    }
}