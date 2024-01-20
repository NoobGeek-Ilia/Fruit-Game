using UnityEngine;

public class Wallet : MonoBehaviour
{
    private static int coinValue;

    internal protected static int CoinValue { get { return coinValue; } set { coinValue = value; } }

    private void Awake()
    {
        CoinValue = PlayerPrefs.GetInt("CoinValue");
    }

    public virtual void DoTransaction(int itemPrice, int index)
    {
        if (itemPrice <= CoinValue)
        {
            CoinValue -= itemPrice;
            PlayerPrefs.SetInt("CoinValue", CoinValue);
        }
    }

    public static void AddCoins(int value)
    {
        CoinValue += value;
        PlayerPrefs.SetInt("CoinValue", CoinValue);
    }

}
