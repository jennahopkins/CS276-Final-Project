using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PersonPickupUI : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI personNameText;
    [SerializeField] private TextMeshProUGUI personDescriptionText;
    [SerializeField] private Button okButton;

    private PersonInstance currentPerson;

    private void Awake()
    {
        panel.SetActive(false);
        okButton.onClick.AddListener(OnOkButtonClicked);
    }

    public void ShowPerson(PersonInstance person)
    {
        currentPerson = person;
        personNameText.text = person.personData.Name;
        personDescriptionText.text = person.personData.Description;
        panel.SetActive(true);
    }

    private void OnOkButtonClicked()
    {
        panel.SetActive(false);
        currentPerson = null;

    }

    public void Hide()
    {
        panel.SetActive(false);
        currentPerson = null;
    }
}