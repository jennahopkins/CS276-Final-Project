using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;

public class Inventory : MonoBehaviour
{
    /* Singleton that manages the player's inventory */
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
        /* Add a clue to the inventory if there is space */

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
        /* Drop a clue from the inventory into the game world */
        Vector3 spawnPos = playerCar.transform.position + (dropOffset * playerCar.transform.up);
        Instantiate(clue.Prefab, spawnPos, Quaternion.identity);
        slot.ClearSlot();
    }

    public bool HasItem(ClueData clue)
    {
        /* Check if the inventory contains a specific clue */
        foreach (InventorySlot slot in slots)
        {
            if (slot.storedClue == clue)
                return true;
        }
        return false;
    }

    public List<ClueData> GetClues()
    {
        /* Get a list of all clues currently in the inventory */
        List<ClueData> clues = new List<ClueData>();

        foreach (InventorySlot slot in slots)
        {
            if (slot.storedClue != null)
                clues.Add(slot.storedClue);
        }

        return clues;
    }
}