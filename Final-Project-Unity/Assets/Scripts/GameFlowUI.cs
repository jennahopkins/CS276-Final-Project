using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameFlowUI : MonoBehaviour
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

    private void Awake()
    {
        startPanel.SetActive(true);
        endPanel.SetActive(false);

        startButton.onClick.AddListener(OnStartClicked);
        restartButton.onClick.AddListener(OnRestartClicked);
    }

    public void ShowEndGame(bool won)
    {
        endPanel.SetActive(true);
        endStoryText.text = won ? "You solved the case!" : "You failed to catch the murderer.";
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
    }
}
