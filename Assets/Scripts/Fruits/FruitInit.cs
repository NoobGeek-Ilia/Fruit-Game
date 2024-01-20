using UnityEngine;

public class FruitInit : MonoBehaviour
{
    [SerializeField] private GameObject[] _fruitsPrefab;
    [SerializeField] private BasketController _basketController;
   
    private bool[] tileIsFull;

    public void FruitInitialisation(int reserveTile)
    {
        tileIsFull = new bool[GridGenerator.GridInfo.GetTileNum];
        tileIsFull[reserveTile] = true;

        int numFruitTypes = _fruitsPrefab.Length;
        int fruitsPerType = _basketController.MaxFruitNum / numFruitTypes;
        int remainder = _basketController.MaxFruitNum % numFruitTypes;

        for (int i = 0; i < numFruitTypes; i++)
        {
            int currentFruits = 0;

            while (currentFruits < fruitsPerType + (i < remainder ? 1 : 0))
            {
                int rand = GridGenerator.GetRandomTileNum();
                while (tileIsFull[rand])
                    rand = GridGenerator.GetRandomTileNum();

                Vector3 tilePos = GridGenerator.GridInfo.GetTilePos(rand);
                float offset = 0.2f;
                Vector3 newPos = new Vector3(tilePos.x, tilePos.y + offset, tilePos.z);

                Instantiate(_fruitsPrefab[i], newPos, _fruitsPrefab[i].transform.rotation, transform);
                tileIsFull[rand] = true;

                currentFruits++;
            }
        }
    }
}
