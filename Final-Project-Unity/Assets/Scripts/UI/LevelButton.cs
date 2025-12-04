using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    /* Button representing a level in the level selection UI */
    public LevelData levelData;
    private Color unlockedColor = Color.white;
    private Color lockedColor = Color.gray;

    private void Awake()
    {
        Image buttonBackground = GetComponent<Image>();
        bool isUnlocked = PlayerProgress.IsLevelUnlocked(levelData.Number);

        // Set button color based on unlock status
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
        /* Load the selected level when the button is clicked */
        SceneLoader.LoadLevel(levelData.Name);
    }
}