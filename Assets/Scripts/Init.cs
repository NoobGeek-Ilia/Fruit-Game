using UnityEngine;

public class Init : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private FruitInit _fruitInit;
    [SerializeField] private Timer _timer;
    private int _playerTileReserve;

    private int _maxTime;

    private void Start()
    {
        _maxTime = (MenuManager.CurrentLevel * 3) + 20;
        new PlayerInit(_player, out _playerTileReserve);
        _fruitInit.FruitInitialisation(_playerTileReserve);
        _timer.SetTimer(_maxTime);
    }
}