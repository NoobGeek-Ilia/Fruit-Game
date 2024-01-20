using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] StartTimer startTimer;
    [SerializeField] TextMeshProUGUI timerText;
    private static int _time;
    public static int TimeValue { get => _time; private set => _time = value; }
    private void OnEnable()
    {
        startTimer.TimeIsUp += () => StartCoroutine(TimerCoroutine());
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

    internal protected Action TimeIsUp;

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

            // Проверка на оставшееся время менее 5 секунд
            if (TimeValue <= 5)
            {
                // Устанавливаем красный цвет текста
                timerText.color = Color.red;
            }
        }
        TimeIsUp?.Invoke();
    }

    private void UpdateTimerText()
    {
        timerText.text = GetFormatedTime;
    }
}
