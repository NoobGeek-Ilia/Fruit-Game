using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    [ContextMenu("Reset PlayerPrefs")]
    private void ResetPlayerPrefses()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("PlayerPrefs סבנמרוםû!");
    }
}
