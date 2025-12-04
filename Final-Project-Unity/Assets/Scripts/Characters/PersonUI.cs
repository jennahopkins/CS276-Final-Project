using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PersonPickupUI : MonoBehaviour
{
    /* UI panel to show person details when clicked */
    
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI personNameText;
    [SerializeField] private TextMeshProUGUI personDescriptionText;
    [SerializeField] private Button okButton;

    private void Awake()
    {
        panel.SetActive(false);
        okButton.onClick.AddListener(OnOkButtonClicked);
    }

    public void ShowPerson(PersonInstance person)
    {
        personNameText.text = person.personData.Name;
        personDescriptionText.text = person.personData.Description;
        panel.SetActive(true);
    }

    private void OnOkButtonClicked()
    {
        panel.SetActive(false);
    }

    public void Hide()
    {
        panel.SetActive(false);
    }
}