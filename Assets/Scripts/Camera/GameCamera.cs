using UnityEngine;

public class GameCamera : MonoBehaviour
{
    private void Start()
    {
        float distanceStep = 1.5f;
        float cameraSize = GetComponent<Camera>().orthographicSize;
        cameraSize = Mathf.Max(0.1f, cameraSize + MenuManager.CurrentLevel * distanceStep);
        GetComponent<Camera>().orthographicSize = cameraSize;
    }
}
