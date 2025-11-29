using UnityEngine;

public class LevelEndManager : MonoBehaviour
{
    [SerializeField] private LevelData currentLevel; 
    [SerializeField] private LevelUI ui; // Assign your UI panel here

    public string GetCurrentLevelName()
    {
        return currentLevel.Name;
    }

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
    }
}