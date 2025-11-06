using UnityEngine;

[CreateAssetMenu(menuName = "Game/Person")]
public class PersonData : ScriptableObject
{
    public string Name;
    public string Description;
    public Sprite Icon;
    public bool IsMurderer;

    public void OnClick(GameObject interactor)
    {
        Debug.Log($"You found: {Name}");
    }
}