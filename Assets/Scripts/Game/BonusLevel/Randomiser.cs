using System.Collections.Generic;
using UnityEngine;

public class Randomiser
{
    internal protected int[] GetFruitIndex { get => fruitArray; }

    private const int maxCardNum = 9;
    private int[] fruitArray = new int[maxCardNum];

    public Randomiser()
    {
        SetIndexForEachCard();
    }

    private void SetIndexForEachCard()
    {
        // создать
        List<int> numbers = new List<int>();
        for (int num = 0; num <= 2; num++)
        {
            for (int count = 0; count < 3; count++)
            {
                numbers.Add(num);
            }
        }

        // перемешать
        for (int i = 0; i < numbers.Count; i++)
        {
            int temp = numbers[i];
            int randomIndex = Random.Range(i, numbers.Count);
            numbers[i] = numbers[randomIndex];
            numbers[randomIndex] = temp;
        }

        // заполнить
        for (int i = 0; i < fruitArray.Length; i++)
        {
            fruitArray[i] = numbers[i];
        }
    }
}
