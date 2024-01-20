using UnityEngine;

public class Platform : MonoBehaviour
{
    private void Start()
    {
        transform.localScale = new Vector3(GridGenerator.GridInfo.GetGridWidth, transform.localScale.y, 
            GridGenerator.GridInfo.GetGridHeight);
    }
}
