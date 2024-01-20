using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiSizeConroller : MonoBehaviour
{
    private void Update()
    {
        float with = gameObject.GetComponent<RectTransform>().rect.width;
        Vector2 newSize = new Vector2(with / 3, with / 3);
        gameObject.GetComponent<GridLayoutGroup>().cellSize = newSize;
    }
}
