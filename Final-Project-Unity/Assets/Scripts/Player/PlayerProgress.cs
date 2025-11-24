using UnityEngine;

public static class PlayerProgress
{
    private const string LEVEL_KEY = "LevelUnlocked_";

    // Check if a level is unlocked
    public static bool IsLevelUnlocked(int levelNumber)
    {
        return PlayerPrefs.GetInt(LEVEL_KEY + levelNumber, levelNumber == 1 ? 1 : 0) == 1;
    }

    // Unlock a level
    public static void UnlockLevel(int levelNumber)
    {
        PlayerPrefs.SetInt(LEVEL_KEY + levelNumber, 1);
        PlayerPrefs.Save();
    }
}