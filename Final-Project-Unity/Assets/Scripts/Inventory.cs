using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;

public interface IInventory
{
    void AddClue(ClueData clue);
    ClueData DropClue(ClueData clue);
    bool HasClue(Func<ClueData, bool> condition);
    List<ClueData> GetClues();
}


public class Inventory : MonoBehaviour, IInventory
{
    public static IInventory Instance { get; private set; }
    public List<ClueData> Clues = new List<ClueData>();

    private void Awake()
    {
        Instance = this;
    }

    public void AddClue(ClueData clue)
    {
        if (clue == null)
        {
            Debug.LogWarning("Tried to add null clue to inventory!");
            return;
        }

        Clues.Add(clue);
        Debug.Log($"[Inventory] Added: {clue.Name}");
    }

    public ClueData DropClue(ClueData clue)
    {
        ClueData foundClue = Clues.Find(c => c.Name == clue.Name && c.Description == clue.Description);
        if (foundClue != null)
        {
            Clues.Remove(foundClue);
            Debug.Log($"[Inventory] Dropped: {foundClue.Name}");
            return foundClue;
        }
        else
        {
            Debug.LogWarning("Tried to drop a clue that is not in inventory!");
            return null;
        }
    }
    public bool HasClue(Func<ClueData, bool> condition) => Clues.Any(condition);

    public List<ClueData> GetClues() => Clues;
}