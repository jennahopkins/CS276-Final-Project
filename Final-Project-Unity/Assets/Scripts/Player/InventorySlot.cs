using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IPointerClickHandler
{
    public Image icon;
    public ClueData storedClue;

    public bool HasItem => storedClue != null;

    public void SetItem(ClueData newClue)
    {
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
        if (storedClue != null)
        {
            Inventory.Instance.DropClue(storedClue, this);
        }
    }
}