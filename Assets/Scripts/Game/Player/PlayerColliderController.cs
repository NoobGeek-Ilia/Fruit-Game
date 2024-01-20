using System;
using UnityEngine;

public class PlayerColliderController : MonoBehaviour
{
    public Action WrongFruitColeded;
    private void OnTriggerEnter(Collider other)
    {
        Fruit fruit = other.GetComponent<Fruit>();
        
        if (fruit.GetFruitIndex() != BasketController.selectedButtonIndex)
        {
            WrongFruitColeded?.Invoke();
        }
        else
            fruit.Collect();
    }
}
