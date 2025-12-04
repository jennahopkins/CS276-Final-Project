using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CluePickupUI : MonoBehaviour
{
    /* UI panel to show clue details when picked up */

    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI clueNameText;
    [SerializeField] private TextMeshProUGUI clueDescriptionText;
    [SerializeField] private Button pickupButton;
    [SerializeField] private Button okayButton;

    private ClueInstance currentClue;

    private void Awake()
    {
        panel.SetActive(false);
        pickupButton.onClick.AddListener(OnPickupButtonClicked);
        okayButton.onClick.AddListener(Hide);
    }

    public void ShowClue(ClueInstance clue)
    {
        /* Display clue info in UI */

        currentClue = clue;
        clueNameText.text = clue.clueData.Name;
        clueDescriptionText.text = clue.clueData.Description;
        panel.SetActive(true);
        AudioManager.Instance.PlaySFX(AudioManager.Instance.clueFoundSound);
    }

    private void OnPickupButtonClicked()
    {
        /* Handle clue pickup */

        if (currentClue != null)
        {
            if (Inventory.Instance.AddClue(currentClue.clueData)) // Add to inventory if space
            {
                panel.SetActive(false);
                Destroy(currentClue.gameObject);
                currentClue = null;
                AudioManager.Instance.PlaySFX(AudioManager.Instance.cluePickupSound);
            }
            else
            {
                clueDescriptionText.text += "\nInventory Full!";
            }
        }
    }

    public void Hide()
    {
        /* Hide the clue UI panel */
        
        panel.SetActive(false);
        currentClue = null;
    }
}