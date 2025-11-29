using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CluePickupUI : MonoBehaviour
{
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
        currentClue = clue;
        clueNameText.text = clue.clueData.Name;
        clueDescriptionText.text = clue.clueData.Description;
        panel.SetActive(true);
    }

    private void OnPickupButtonClicked()
    {
        if (currentClue != null)
        {
            if (Inventory.Instance.AddClue(currentClue.clueData)) // Add to inventory
            {
                panel.SetActive(false);
                Destroy(currentClue.gameObject);
                currentClue = null;
            }
            else
            {
                clueDescriptionText.text += "\nInventory Full!";
            }
        }
    }

    public void Hide()
    {
        panel.SetActive(false);
        currentClue = null;
    }
}