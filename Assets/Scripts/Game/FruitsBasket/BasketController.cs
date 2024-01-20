using System;
using UnityEngine;
using UnityEngine.UI;

public class BasketController : MonoBehaviour
{
    [SerializeField] private Button[] buttons;

    public int GetCurrentFruitNum { get => _colectedFruitsNum; }
    public static int selectedButtonIndex;
    public int MaxFruitNum;

    internal protected static Action BasketIsFull;

    private int _colectedFruitsNum;

    private void Awake()
    {
        MaxFruitNum = 3 + (GameManager.LevelNum * 2);
    }
    private void Start()
    {
        OnButtonClick(0);
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i;
            buttons[i].onClick.AddListener(() => OnButtonClick(index));
        }
    }

    private void OnButtonClick(int buttonIndex)
    {
        foreach (Button button in buttons)
            button.image.color = Color.blue;
        buttons[buttonIndex].image.color = Color.green;
        selectedButtonIndex = buttonIndex;
    }
    public void AddFruitInBasket()
    {
        _colectedFruitsNum++;
        if (_colectedFruitsNum == MaxFruitNum)
            BasketIsFull?.Invoke();
    }
}
