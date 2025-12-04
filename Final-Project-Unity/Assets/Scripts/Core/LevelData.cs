using UnityEngine;

[CreateAssetMenu(menuName = "Game/Level")]
public class LevelData : ScriptableObject
{
    /* Level data for each level in the game */
    
    public string Name;
    public int Number;
    public float Time; 
}