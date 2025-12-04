using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    /* Handles loading of game scenes */

    public static void LoadLevel(string levelName)
    {
        /* Load specified level and play level music */

        SceneManager.LoadScene(levelName);
        AudioManager.Instance.PlayMusic(AudioManager.Instance.levelMusic);
    }

    public static void LoadMainMenu()
    {
        /* Load main menu scene and play menu music */

        SceneManager.LoadScene("MainScene");
        AudioManager.Instance.PlayMusic(AudioManager.Instance.menuMusic);
    }
}