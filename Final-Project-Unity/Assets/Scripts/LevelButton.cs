using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public LevelData levelData; // Set in Inspector
    private Color unlockedColor = Color.white;
    private Color lockedColor = Color.gray;

    private void Awake()
    {
        Image buttonBackground = GetComponent<Image>();
        bool isUnlocked = PlayerProgress.IsLevelUnlocked(levelData.Number);

        if(buttonBackground != null)
            buttonBackground.color = isUnlocked ? unlockedColor : lockedColor;

        // Set button interactivity
        var button = GetComponent<Button>();
        button.interactable = isUnlocked;
        button.onClick.AddListener(OnClick);
    }

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        SceneLoader.LoadLevel(levelData.Name);
    }
}