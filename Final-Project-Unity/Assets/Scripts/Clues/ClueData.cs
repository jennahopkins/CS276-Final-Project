
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Clue")]
public class ClueData : ScriptableObject
{
    /* Clue data for items that can be collected in the game */

    public string Name;
    public string Description;
    public Sprite Icon;
    public bool WinClue;
    public GameObject Prefab;
}