
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Clue")]
public class ClueData : ScriptableObject
{
    public string Name;
    public string Description;
    public Sprite Icon;
    public bool WinClue;

    public void OnClick(GameObject interactor)
    {
        Debug.Log($"You found: {Name}");

        // Add to inventory — depends on abstraction, not specific class
        IInventory inventory = Inventory.Instance;
        if (inventory != null)
        {
            inventory.AddClue(this);
        }
        else
        {
            Debug.LogWarning("No inventory system found!");
        }

        // remove the clue from the world
        if (interactor != null)
        {
            GameObject.Destroy(interactor);
        }
    }
}