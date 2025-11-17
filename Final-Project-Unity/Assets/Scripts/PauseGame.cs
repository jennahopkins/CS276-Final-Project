using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuPanel;
    [SerializeField] private Button pauseButton;


    private void Start()
    {
        pauseMenuPanel.SetActive(false); // ensure hidden at start
        pauseButton.gameObject.SetActive(true);
    }

    public void Pause()
    {
        pauseMenuPanel.SetActive(true);
        Time.timeScale = 0f; // freeze game
        pauseButton.gameObject.SetActive(false);
    }

    public void Resume()
    {
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f; // resume game
        pauseButton.gameObject.SetActive(true);
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1f; // ensure time is running
        pauseButton.gameObject.SetActive(true);
        SceneLoader.LoadMainMenu();
    }
}