using UnityEngine;
using TMPro;

public class TimerUI : MonoBehaviour
{
    /* UI component to display and manage the level timer */

    [SerializeField] private TextMeshProUGUI timerText;

    private bool tickingStarted = false;
    private float tickTimer = 0f;
    private const float tickCooldown = 1f; // Tick every second

    private void OnEnable()
    {
        /* Subscribe to timer events */

        if (TimerManager.Instance != null)
        {
            TimerManager.Instance.OnTimeChanged += UpdateTimerDisplay;
            TimerManager.Instance.OnTimeUp += OnTimeUp;
        }
    }

    private void OnDisable()
    {
        /* Unsubscribe from timer events */

        if (TimerManager.Instance != null)
        {
            TimerManager.Instance.OnTimeChanged -= UpdateTimerDisplay;
            TimerManager.Instance.OnTimeUp -= OnTimeUp;
        }
    }

    private void UpdateTimerDisplay(float remaining)
    {
        /* Update the timer display each frame */

        if (remaining < 11) 
        {
            // when under 10 seconds, change color and start ticking sound
            timerText.color = Color.red;
            tickingStarted = true;
        }

        if (tickingStarted)
        {
            // handle ticking sound effect
            tickTimer -= Time.deltaTime;
            if (tickTimer <= 0f)
            {
                tickTimer = tickCooldown;  
                AudioManager.Instance.PlaySFX(AudioManager.Instance.clockTick);
            }
        }

        // format time as MM:SS
        int minutes = Mathf.FloorToInt(remaining / 60);
        int seconds = Mathf.FloorToInt(remaining % 60);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }

    private void OnTimeUp()
    {
        /* Handle timer reaching zero */
        
        timerText.text = "TIME'S UP!";
    }
}
