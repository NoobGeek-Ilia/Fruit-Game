using UnityEngine;

public abstract class Fruit : MonoBehaviour
{
    [SerializeField] protected ParticleSystem CollectEffect;

    protected int fruitIndex;

    private bool isCollected = false;

    public abstract Color GetFruitColor();
    public int GetFruitIndex() => fruitIndex;

    public void SetFruitIndex(int index) => fruitIndex = index;
    
    public void Collect()
    {
        if (!isCollected)
        {
            isCollected = true;
            DestroyEffect(transform.position);
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
            var mainModule = newEffect.main;
            mainModule.startColor = GetFruitColor();
            newEffect.Play();
        }
    }
}
