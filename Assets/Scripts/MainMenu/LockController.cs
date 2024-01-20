using UnityEngine;
using UnityEngine.UI;

public class LockController : MonoBehaviour
{
    internal protected bool[] LevelOpened = new bool[LevelsPanel._LevelNum];

    private void Start()
    {
        CheckLockOnLvl();
        if (!PlayerPrefs.HasKey("BoughtLvlInfo_0"))
        {
            LevelOpened[0] = true;
            PlayerPrefs.SetInt("BoughtLvlInfo_0", 1);
        }
    }

    public void UnlockLevel(Button button)
    {
        Transform buttonChild = button.transform.GetChild(1);
        if (buttonChild != null)
        {
            buttonChild.gameObject.SetActive(false);
        }
    }

    public void OpenLevel(int index)
    {
        LevelOpened[index] = true;
        PlayerPrefs.SetInt("BoughtLvlInfo_" + index, 1);
    }

    public void CheckLockOnLvl()
    {
        for (int i = 0; i < LevelOpened.Length; i++)
        {
            bool levelIsOpen = PlayerPrefs.GetInt("BoughtLvlInfo_" + i) == 1;
            LevelOpened[i] = levelIsOpen;
        }
    }

    public void CheckLockOnLvl(int index)
    {
        bool levelIsOpen = PlayerPrefs.GetInt("BoughtLvlInfo_" + index) == 1;
        LevelOpened[index] = levelIsOpen;
    }
}
