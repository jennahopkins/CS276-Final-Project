using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set; }
    public InventorySlot[] slots;
    public Transform playerCar;
    public float dropOffset = -2f;

    private void Awake()
    {
        Instance = this;
    }

    public bool AddClue(ClueData clue)
    {
        foreach (InventorySlot slot in slots)
        {
            if (!slot.HasItem)
            {
                slot.SetItem(clue);
                return true;
            }
        }
        return false; // No space
    }

    public void DropClue(ClueData clue, InventorySlot slot)
    {
        Vector3 spawnPos = playerCar.transform.position + (dropOffset * playerCar.transform.up);

        Instantiate(clue.Prefab, spawnPos, Quaternion.identity);

        slot.ClearSlot();
    }

    public bool HasItem(ClueData clue)
    {
        foreach (InventorySlot slot in slots)
        {
            if (slot.storedClue == clue)
                return true;
        }
        return false;
    }

    public List<ClueData> GetClues()
    {
        List<ClueData> clues = new List<ClueData>();

        foreach (InventorySlot slot in slots)
        {
            if (slot.storedClue != null)
                clues.Add(slot.storedClue);
        }

        return clues;
    }
}