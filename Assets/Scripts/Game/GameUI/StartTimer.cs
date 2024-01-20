using System;
using System.Collections;
using UnityEngine;

public class StartTimer : MonoBehaviour
{
    public Action TimeIsUp;
    private int _timer = 3;
    public int Timer { get => _timer; private set => _timer = value; }
    private void Awake()
    {
        StartCoroutine(TimerCoroutine());   
    }
    private IEnumerator TimerCoroutine()
    {
        while (_timer > 0)
        {
            yield return new WaitForSeconds(1f);
            Timer--;
        }
        TimeIsUp?.Invoke();
        gameObject.SetActive(false);
    }
}
