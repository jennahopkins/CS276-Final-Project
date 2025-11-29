using UnityEngine;
using System;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
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
        if (!isRunning) return;

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

        OnTimeChanged?.Invoke(remainingTime);
    }

    public void StartTimer(float levelDuration)
    {
        remainingTime = levelDuration;
        isRunning = true;
        endButton.gameObject.SetActive(true);
    }

    public void StopTimer() => isRunning = false;

    public float GetRemainingTime() => remainingTime;

    public void EndEarly()
    {
        if (!isRunning) return;

        remainingTime = 0;
        isRunning = false;
        endButton.gameObject.SetActive(false);
        AudioManager.Instance.PlayMusic(AudioManager.Instance.endLevelMusic);
        OnTimeUp?.Invoke();
    }
}