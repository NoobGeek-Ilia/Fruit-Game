using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsController : Wallet
{
    [SerializeField] LockController lockController;
    PriceList priceList = new PriceList();
    public void SetupButton(Button button, int levelIndex)
    {
        TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
        buttonText.text = $"Уровень {levelIndex + 1}";

        Transform priceTextTransform = button.transform.GetChild(1);
        TextMeshProUGUI priceText = priceTextTransform.GetComponentInChildren<TextMeshProUGUI>();
        priceText.text = $"{priceList.LevelPrice[levelIndex]}$";


        button.onClick.AddListener(() => OnButtonClick(button, levelIndex));
        lockController.CheckLockOnLvl(levelIndex);
        UpdateButtonState(button, levelIndex);
    }

    private void OnButtonClick(Button button, int currLevel)
    {
        if (lockController.LevelOpened[currLevel])
        {
            string sceneName = "Game";
            MenuManager.CurrentLevel = currLevel + 1;
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            DoTransaction(priceList.LevelPrice[currLevel], currLevel);
            lockController.UnlockLevel(button);
            UpdateButtonState(button, currLevel);
        }
    }

    public new void DoTransaction(int itemPrice, int index)
    {
        if (itemPrice <= CoinValue)
        {
            lockController.OpenLevel(index);
        }
        base.DoTransaction(itemPrice, index);
    }

    private void UpdateButtonState(Button button, int index)
    {
        Transform buttonChild = button.transform.GetChild(1);
        if (buttonChild != null)
        {
            buttonChild.gameObject.SetActive(index > 0 && !lockController.LevelOpened[index]);
        }
    }
}
