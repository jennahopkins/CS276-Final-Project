using UnityEngine;
using UnityEngine.InputSystem;


public class ClueInstance : MonoBehaviour, IClickable
{
    /* Instance of a clue in the game world */

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
        /* Trigger interaction with this clue */
        
        if (clueData == null)
        {
            Debug.LogWarning("No ClueData assigned!");
            return;
        }

        cluePickupUI.ShowClue(this);
    }
}