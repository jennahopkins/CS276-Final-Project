using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CluePickupUI : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI clueNameText;
    [SerializeField] private TextMeshProUGUI clueDescriptionText;
    [SerializeField] private Button pickupButton;

    private ClueInstance currentClue;

    private void Awake()
    {
        panel.SetActive(false);
        pickupButton.onClick.AddListener(OnPickupButtonClicked);
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
            Inventory.Instance.AddClue(currentClue.clueData); // Add to inventory
            Debug.Log($"Picked up: {currentClue.clueData.Name}");
            panel.SetActive(false);
            Destroy(currentClue.gameObject);
            currentClue = null;
        }
    }

    public void Hide()
    {
        panel.SetActive(false);
        currentClue = null;
    }
}