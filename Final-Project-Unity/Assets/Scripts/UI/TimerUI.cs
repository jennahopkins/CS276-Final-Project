using UnityEngine;
using TMPro;

public class TimerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;

    private void OnEnable()
    {
        if (TimerManager.Instance != null)
        {
            TimerManager.Instance.OnTimeChanged += UpdateTimerDisplay;
            TimerManager.Instance.OnTimeUp += OnTimeUp;
        }
    }

    private void OnDisable()
    {
        if (TimerManager.Instance != null)
        {
            TimerManager.Instance.OnTimeChanged -= UpdateTimerDisplay;
            TimerManager.Instance.OnTimeUp -= OnTimeUp;
        }
    }

    private void UpdateTimerDisplay(float remaining)
    {
        if (remaining <= 10) timerText.color = Color.red;

        int minutes = Mathf.FloorToInt(remaining / 60);
        int seconds = Mathf.FloorToInt(remaining % 60);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }

    private void OnTimeUp()
    {
        timerText.text = "TIME'S UP!";
    }
}
