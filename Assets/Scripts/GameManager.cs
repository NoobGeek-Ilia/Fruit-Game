using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] private Timer timer;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private PlayerColliderController _playerColliderController;
    public static int LevelNum { get => MenuManager.CurrentLevel; }

    private void Start()
    {
        BasketController.BasketIsFull += OpenWinPanel;
        timer.TimeIsUp += OpenGameOverPanel;
        _playerColliderController.WrongFruitColeded += OpenGameOverPanel;
    }

    private void OpenWinPanel()
    {
        SceneManager.LoadScene("Bonus");
    }
    private void OpenGameOverPanel()
    {
        _gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }
}
