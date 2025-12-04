using UnityEngine;
using System;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    /* Singleton that manages the level timers */

    public static TimerManager Instance { get; private set; }
    [SerializeField] private Button endButton;
    private float remainingTime;
    private bool isRunning;

    public event Action<float> OnTimeChanged;
    public event Action OnTimeUp;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        // don't update timer if not running
        if (!isRunning) return;

        // decrement time
        remainingTime -= Time.deltaTime;
        if (remainingTime < 0)
        {
            remainingTime = 0;
            isRunning = false;
            AudioManager.Instance.PlayMusic(AudioManager.Instance.endLevelMusic);
            endButton.gameObject.SetActive(false);
            OnTimeUp?.Invoke(); // Notify listeners that time’s up
            return;
        }

        OnTimeChanged?.Invoke(remainingTime); // Notify listeners of time change
    }

    public void StartTimer(float levelDuration)
    {
        /* Start the timer with a specified duration */
        remainingTime = levelDuration;
        isRunning = true;
        endButton.gameObject.SetActive(true);
    }

    public void StopTimer() => isRunning = false;

    public float GetRemainingTime() => remainingTime;

    public void EndEarly()
    {
        /* End the timer and level immediately */
        if (!isRunning) return;

        remainingTime = 0;
        isRunning = false;
        endButton.gameObject.SetActive(false);
        AudioManager.Instance.PlayMusic(AudioManager.Instance.endLevelMusic);
        OnTimeUp?.Invoke(); // Notify listeners that time’s up
    }
}