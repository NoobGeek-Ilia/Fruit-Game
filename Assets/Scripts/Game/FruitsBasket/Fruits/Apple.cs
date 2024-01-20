using UnityEngine;

public class Apple : Fruit
{
    [SerializeField] private Color appleColor;

    private void Start()
    {
        SetFruitIndex(3);
    }
    public override Color GetFruitColor()
    {
        return appleColor;
    }
}
