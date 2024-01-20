using TMPro;
using UnityEngine;

public class MainManagerUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinsTxt;
    private void Update()
    {
        coinsTxt.text = $"{Wallet.CoinValue}$";
    }
}
