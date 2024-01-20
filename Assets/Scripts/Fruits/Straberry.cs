using UnityEngine;

public class Strawberry : Fruit
{
    [SerializeField] private Color strawberryColor;

    private void Start()
    {
        SetFruitIndex(0);
    }
    public override Color GetFruitColor()
    {
        return strawberryColor;
    }
}