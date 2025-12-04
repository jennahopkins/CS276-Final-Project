using UnityEngine;

public class LevelEndManager : MonoBehaviour
{
    /* Manages the end of the level */

    [SerializeField] private LevelData currentLevel; 
    [SerializeField] private LevelUI ui;

    public string GetCurrentLevelName()
    {
        return currentLevel.Name;
    }

    public void EndLevel(bool playerWon)
    {
        /* Handle end of level logic */

        if (ui != null)
            ui.ShowEndGame(playerWon, currentLevel.Number);

        if (playerWon)
            UnlockNextLevel();
    }

    private void UnlockNextLevel()
    {
        /* Unlock the next level upon winning the current level */
        
        int nextLevelNumber = currentLevel.Number + 1;
        PlayerProgress.UnlockLevel(nextLevelNumber);
    }
}