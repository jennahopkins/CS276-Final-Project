using UnityEngine;
using UnityEngine.InputSystem;


public class ClueInstance : MonoBehaviour, IClickable
{
    [SerializeField] public ClueData clueData;
    [SerializeField] private LayerMask clueLayer;
    private CluePickupUI cluePickupUI;

    private void Start()
    {
        cluePickupUI = Object.FindAnyObjectByType<CluePickupUI>();
    }

    public void Update()
    {
        // Check if the left mouse button was pressed
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

            // Check if the mouse clicked this object's 2D collider
            Collider2D col = Physics2D.OverlapPoint(mousePos, clueLayer);
            if (col != null && col.gameObject == gameObject)
            {
                Trigger();
            }
        }
    }

    public void Trigger()
    {
        if (clueData == null)
        {
            Debug.LogWarning("No ClueData assigned!");
            return;
        }

        Debug.Log($"Clicked on {clueData.Name}");
        cluePickupUI.ShowClue(this);
    }
}