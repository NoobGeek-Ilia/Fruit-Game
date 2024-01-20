using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] StartTimer startTimer;
    [SerializeField] TextMeshProUGUI timerText;

    public static int TimeValue { get => _time; private set => _time = value; }

    internal protected Action TimeIsUp;

    private static int _time;
    
    private void OnEnable()
    {
        startTimer.TimeIsUp += () => StartCoroutine(TimerCoroutine());
    }

    private void OnDisable()
    {
        startTimer.TimeIsUp -= () => StartCoroutine(TimerCoroutine());
    }

    public static string GetFormatedTime
    {
        get
        {
            int minutes = TimeValue / 60;
            int seconds = TimeValue % 60;
            return $"{minutes:0}:{seconds:00}";
        }
    }

    public void SetTimer(int time)
    {
        _time = time;
        UpdateTimerText();
    }

    private IEnumerator TimerCoroutine()
    {
        while (TimeValue > 0)
        {
            yield return new WaitForSeconds(1f);
            TimeValue--;
            UpdateTimerText();

            if (TimeValue <= 5)
                timerText.color = Color.red;
        }
        TimeIsUp?.Invoke();
    }

    private void UpdateTimerText()
    {
        timerText.text = GetFormatedTime;
    }
}
