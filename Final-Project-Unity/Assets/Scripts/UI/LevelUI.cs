using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject endPanel;

    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI startStoryText;
    [SerializeField] private TextMeshProUGUI endStoryText;

    [Header("Buttons")]
    [SerializeField] private Button startButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button nextLevelButton;

    private string nextLevelName;

    private void Awake()
    {
        startPanel.SetActive(true);
        endPanel.SetActive(false);

        startButton.onClick.AddListener(OnStartClicked);
        restartButton.onClick.AddListener(OnRestartClicked);
        mainMenuButton.onClick.AddListener(OnMainMenuClicked);
        nextLevelButton.onClick.AddListener(OnNextLevelClicked);
    }

    public void ShowEndGame(bool won, int levelNumber)
    {
        endPanel.SetActive(true);
        endStoryText.text = won ? "You solved the case!" : "You failed to catch the murderer.";
        if (won)
        {
            nextLevelName = "Level" + (levelNumber + 1);
            Debug.Log("Level" + (levelNumber + 1));
            nextLevelButton.gameObject.SetActive(true);
        }
        else
        {
            nextLevelButton.gameObject.SetActive(false);
            nextLevelName = "";
        }
    }

    private void OnStartClicked()
    {
        startPanel.SetActive(false);
        // Optional: notify GameManager that the level has started
        GameManager.Instance.StartLevel();
    }

    private void OnRestartClicked()
    {
        // Reload the current scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        GameManager.Instance.StartLevel();
    }

    private void OnMainMenuClicked()
    {
        // Load the main menu scene
        SceneLoader.LoadMainMenu();
    }

    private void OnNextLevelClicked()
    {
        // Load the next level scene
        SceneLoader.LoadLevel(nextLevelName);
    }
}
