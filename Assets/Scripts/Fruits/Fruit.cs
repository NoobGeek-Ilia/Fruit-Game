using UnityEngine;

public abstract class Fruit : MonoBehaviour
{
    [SerializeField] protected ParticleSystem CollectEffect;
    //[SerializeField] private BasketController _basketController;
    protected int fruitIndex;  // Индекс фрукта
    private bool isCollected = false;

    public abstract Color GetFruitColor(); // Абстрактный метод для получения цвета
    public int GetFruitIndex() => fruitIndex; // Метод для получения индекса фрукта

    public void SetFruitIndex(int index)
    {
        fruitIndex = index;
    }

    
    public void Collect()
    {
        if (!isCollected)
        {
            isCollected = true;
            DestroyEffect(transform.position); // Передача текущей позиции объекта
            Destroy(gameObject);
            BasketController basketController = FindObjectOfType<BasketController>();
            basketController.AddFruitInBasket();
            Debug.Log("collected");
        }
    }
    public void DestroyEffect(Vector3 position)
    {
        if (CollectEffect != null)
        {
            ParticleSystem newEffect = Instantiate(CollectEffect, position, Quaternion.identity);

            // Установка цвета частиц для новой системы частиц
            var mainModule = newEffect.main;
            mainModule.startColor = GetFruitColor();

            // Воспроизведение эффекта частиц для новой системы частиц
            newEffect.Play();
        }
    }
}
