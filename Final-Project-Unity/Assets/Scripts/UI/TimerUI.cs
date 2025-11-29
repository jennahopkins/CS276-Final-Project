using UnityEngine;
using TMPro;

public class TimerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;

    private bool tickingStarted = false;
    private float tickTimer = 0f;
    private const float tickCooldown = 1f; // Tick every second

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
        if (remaining < 11) 
        {
            timerText.color = Color.red;
            tickingStarted = true;
        }

        if (tickingStarted)
        {
            tickTimer -= Time.deltaTime;
            if (tickTimer <= 0f)
            {
                tickTimer = tickCooldown;  
                AudioManager.Instance.PlaySFX(AudioManager.Instance.clockTick);
            }
        }

        int minutes = Mathf.FloorToInt(remaining / 60);
        int seconds = Mathf.FloorToInt(remaining % 60);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }

    private void OnTimeUp()
    {
        timerText.text = "TIME'S UP!";
    }
}
