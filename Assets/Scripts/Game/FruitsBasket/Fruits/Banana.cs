using UnityEngine;

public class Banana : Fruit
{
    [SerializeField] private Color bananaColor;

    private void Start()
    {
        SetFruitIndex(1);
    }
    public override Color GetFruitColor()
    {
        return bananaColor;
    }
}