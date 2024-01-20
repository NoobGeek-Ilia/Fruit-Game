using UnityEngine;

public class Cherry : Fruit
{
    [SerializeField] private Color cherryColor;

    private void Start()
    {
        SetFruitIndex(2);
    }
    public override Color GetFruitColor()
    {
        return cherryColor;
    }
}
