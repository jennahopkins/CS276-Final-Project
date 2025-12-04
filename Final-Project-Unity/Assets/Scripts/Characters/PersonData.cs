using UnityEngine;

[CreateAssetMenu(menuName = "Game/Person")]
public class PersonData : ScriptableObject
{
    /* Person data for characters in the game */
    
    public string Name;
    public string Description;
    public bool IsMurderer;

}