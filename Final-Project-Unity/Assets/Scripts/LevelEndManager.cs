using UnityEngine;

public class LevelEndManager : MonoBehaviour
{
    [SerializeField] private LevelData currentLevel; 
    [SerializeField] private LevelUI ui; // Assign your UI panel here

    public void EndLevel(bool playerWon)
    {
        if (ui != null)
            ui.ShowEndGame(playerWon, currentLevel.Number);

        if (playerWon)
            UnlockNextLevel();
    }

    private void UnlockNextLevel()
    {
        int nextLevelNumber = currentLevel.Number + 1;
        PlayerProgress.UnlockLevel(nextLevelNumber);
        Debug.Log($"Level {currentLevel.Number} completed! Level {nextLevelNumber} unlocked.");
    }
}