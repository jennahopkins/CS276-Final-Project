using UnityEngine;
using UnityEngine.InputSystem;


public class PersonInstance : MonoBehaviour, IClickable
{
    [SerializeField] public PersonData personData;
    [SerializeField] private LayerMask personLayer;

    private PersonPickupUI personPickupUI;

    private void Start()
    {
        personPickupUI = Object.FindAnyObjectByType<PersonPickupUI>();
    }
    public void Update()
    {
        // Check if the left mouse button was pressed
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

            // Check if the mouse clicked this object's 2D collider
            Collider2D col = Physics2D.OverlapPoint(mousePos, personLayer);
            if (col != null && col.gameObject == gameObject)
            {
                Trigger();
            }
        }
    }

    public void Trigger()
    {
        if (personData == null)
        {
            Debug.LogWarning("No ClueData assigned!");
            return;
        }

        personPickupUI.ShowPerson(this);
    }
}