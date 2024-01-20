using System.Collections;
using TMPro;
using UnityEngine;

public class BonusUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinsSumTxt;
    [SerializeField] private BonusLevelManager _bonusLevelManager;
    [SerializeField] private GameObject _homeButton;

    private int _coinsSum = 0;

    private void Start()
    {
        _coinsSum = _bonusLevelManager._coins;
        _coinsSumTxt.text = $"{_coinsSum} $";
        _bonusLevelManager.GetBonus += () => StartCoroutine(BonusAnim());
       
    }
    private IEnumerator BonusAnim()
    {
        while (_coinsSum < _bonusLevelManager._bonus + _bonusLevelManager._coins)
        {
            yield return new WaitForSeconds(0.1f);
            _coinsSum++;
            _coinsSumTxt.text = $"{_coinsSum} $";
        }
        _homeButton.SetActive(true);
    }
}
