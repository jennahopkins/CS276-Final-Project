using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    /* Manages the pause menu functionality */
    [SerializeField] private GameObject pauseMenuPanel;
    [SerializeField] private Button pauseButton;


    private void Start()
    {
        pauseMenuPanel.SetActive(false); // ensure hidden at start
        pauseButton.gameObject.SetActive(true);
    }

    public void Pause()
    {
        /* Show pause menu and freeze game */

        pauseMenuPanel.SetActive(true);
        pauseMenuPanel.SetActive(true);
        Time.timeScale = 0f; // freeze game
        pauseButton.gameObject.SetActive(false);
    }

    public void Resume()
    {
        /* Hide pause menu and resume game */

        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f; // resume game
        pauseButton.gameObject.SetActive(true);
    }

    public void BackToMainMenu()
    {
        /* Return to main menu from pause menu */
        
        Time.timeScale = 1f; // ensure time is running
        pauseButton.gameObject.SetActive(true);
        SceneLoader.LoadMainMenu();
    }
}