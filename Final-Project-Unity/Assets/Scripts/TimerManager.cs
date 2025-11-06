using UnityEngine;
using System;

public class TimerManager : MonoBehaviour
{
    public static TimerManager Instance { get; private set; }

    [SerializeField] private float levelDuration = 120f; // secoonds
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
        if (!isRunning) return;

        remainingTime -= Time.deltaTime;
        if (remainingTime < 0)
        {
            remainingTime = 0;
            isRunning = false;
            OnTimeUp?.Invoke(); // Notify listeners that time’s up
        }

        OnTimeChanged?.Invoke(remainingTime);
    }

    public void StartTimer()
    {
        remainingTime = levelDuration;
        isRunning = true;
    }

    public void StopTimer() => isRunning = false;

    public float GetRemainingTime() => remainingTime;
}