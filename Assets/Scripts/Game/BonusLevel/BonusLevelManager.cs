using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BonusLevelManager : MonoBehaviour
{
    public Action GetBonus;

    [SerializeField] TextMeshProUGUI allCoinsTxt;
    [SerializeField] GameObject losePanel;
    [SerializeField] Button[] buttons;
    [SerializeField] Sprite[] sprites;

    internal protected int _coins;
    internal protected int _bonus;

    private Randomiser randomiser;
    private List<int> sameFruitSum = new List<int>();
    private const int _coinsDefValue = 100;
    private const int _bonusDefValue = 50;
    private bool[] buttonClicked;

    private void Awake()
    {
        Init();
    }

    void Init()
    {
        _coins = _coinsDefValue + (GameManager.LevelNum * 6);
        _bonus = _bonusDefValue + (GameManager.LevelNum * 2);
        randomiser = new();
        buttonClicked = new bool[buttons.Length];

        for (int i = 0; i < buttons.Length; i++)
        {
            int levelIndex = i;
            buttons[i].onClick.AddListener(() => OnButtonClick(levelIndex));
        }
    }

    private void OnButtonClick(int index)
    {
        if (!buttonClicked[index])
        {
            buttonClicked[index] = true;

            buttons[index].GetComponent<Image>().sprite = sprites[randomiser.GetFruitIndex[index]];
            buttons[index].GetComponent<Image>().color = Color.white;
            CheckFruitSum(randomiser.GetFruitIndex[index]);
        }
    }

    private void CheckFruitSum(int index)
    {
        sameFruitSum.Add(index);
        for (int i = 0; i < sameFruitSum.Count; i++)
        {
            if (sameFruitSum[i] != index)
            {
                Lose();
                return;
            }
        }
        if (sameFruitSum.Count > 2)
        {
            Win();
            foreach (Button button in buttons)
            {
                button.interactable = false;
            }
        }
    }

    private void Lose()
    {
        losePanel.SetActive(true);
        allCoinsTxt.text = $"Получено {_coins}$";
        Wallet.AddCoins(_coins);
    }

    private void Win()
    {
        Wallet.AddCoins(_coins + _bonus);
        GetBonus?.Invoke();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }
}
