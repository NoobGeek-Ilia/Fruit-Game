using UnityEngine;
using UnityEngine.UI;

public class LevelsPanel : Wallet
{
    public const int _LevelNum = 8;

    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private Transform container;
    [SerializeField] private ButtonsController buttonsController;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        for (int i = 0; i < _LevelNum; i++)
        {
            int levelIndex = i; // ������� ��������� ����������

            GameObject buttonObject = Instantiate(buttonPrefab, container);
            Button buttonComponent = buttonObject.GetComponent<Button>();

            // ���������� ���������� ��� ��������� ������
            buttonsController.SetupButton(buttonComponent, levelIndex);
        }
    }
}
