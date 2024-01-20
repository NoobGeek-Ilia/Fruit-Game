using System.Collections.Generic;
using UnityEngine;

public class Randomiser
{
    private const int maxCardNum = 9;
    private int[] fruitArray = new int[maxCardNum];
    internal protected int[] GetFruitIndex { get => fruitArray; }

    public Randomiser()
    {
        SetIndexForEachCard();
    }

    void SetIndexForEachCard()
    {
        // ������� ������, ���������� ����� �� 0 �� 2 �� ��� ���� ������
        List<int> numbers = new List<int>();
        for (int num = 0; num <= 2; num++)
        {
            for (int count = 0; count < 3; count++)
            {
                numbers.Add(num);
            }
        }

        // ������������ ������
        for (int i = 0; i < numbers.Count; i++)
        {
            int temp = numbers[i];
            int randomIndex = Random.Range(i, numbers.Count);
            numbers[i] = numbers[randomIndex];
            numbers[randomIndex] = temp;
        }

        // ��������� ������ ���������� �������
        for (int i = 0; i < fruitArray.Length; i++)
        {
            fruitArray[i] = numbers[i];
            Debug.Log(fruitArray[i]);  // ������ ������� ��� ������, ��� ����� ��� �������
        }
    }
}
