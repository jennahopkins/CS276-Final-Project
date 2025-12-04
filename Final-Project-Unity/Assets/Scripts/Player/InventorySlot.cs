using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IPointerClickHandler
{
    /* Represents a single slot in the player's inventory */
    public Image icon;
    public ClueData storedClue;
    public bool HasItem => storedClue != null;

    public void SetItem(ClueData newClue)
    {
        /* Set the clue item in this inventory slot */

        storedClue = newClue;
        icon.sprite = newClue.Icon;
        icon.enabled = true;

        Image bg = GetComponent<Image>();
        if (bg != null)
        {
            Color c = bg.color;
            c.a = 1f;       // 1 = 255 alpha
            bg.color = c;
        }
    }

    public void ClearSlot()
    {
        /* Clear the clue item from this inventory slot */
        storedClue = null;
        icon.sprite = null;
        icon.enabled = false;

        Image bg = GetComponent<Image>();
        if (bg != null)
        {
            Color c = bg.color;
            c.a = 0f;   // 0 opacity
            bg.color = c;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        /* Handle click events on the inventory slot */
        if (storedClue != null)
        {
            Inventory.Instance.DropClue(storedClue, this);
        }
    }
}