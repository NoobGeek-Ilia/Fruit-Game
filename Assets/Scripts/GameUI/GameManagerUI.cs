using TMPro;
using UnityEngine;

public class GameManagerUI : MonoBehaviour
{
    [SerializeField] private BasketController _basketController;
    [SerializeField] private StartTimer _startTimer;

    [SerializeField] private TextMeshProUGUI _levelMonitor;
    [SerializeField] private TextMeshProUGUI _TimerMonitor;
    [SerializeField] private TextMeshProUGUI _FruitNum;
    [SerializeField] private TextMeshProUGUI _StartTimer;

    private void Start()
    {
        _levelMonitor.text = $"LVL {MenuManager.CurrentLevel}";
        
    }
    private void Update()
    {
        _TimerMonitor.text = Timer.GetFormatedTime;
        _FruitNum.text = $"{_basketController.GetCurrentFruitNum}/{_basketController.MaxFruitNum}";
        _StartTimer.text = _startTimer.Timer.ToString();
    }
}
