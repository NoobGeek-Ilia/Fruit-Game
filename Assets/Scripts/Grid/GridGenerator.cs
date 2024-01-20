using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private Color _evenColor = Color.white;
    [SerializeField] private Color _oddColor = Color.blue;

    public static GridInfo GridInfo { get; private set; }

    private void Awake()
    {
        int gridSize = 5 + MenuManager.CurrentLevel;
        Debug.Log(gridSize);
        GridInfo = new GridInfo(gridSize, gridSize, _tilePrefab);
        GenerateGrid(GridInfo);
    }

    private void GenerateGrid(GridInfo gInfo)
    {
        for (int x = 0; x < gInfo.GetGridWidth; x++)
        {
            for (int z = 0; z < gInfo.GetGridHeight; z++)
            {
                float offsetX = x - (gInfo.GetGridWidth - 1) / 2.0f;
                float offsetZ = z - (gInfo.GetGridHeight - 1) / 2.0f;

                Vector3 newPos = new Vector3(offsetX, 0, offsetZ);
                GameObject tile = Instantiate(_tilePrefab, newPos, Quaternion.identity);
                SetColor(tile, x, z);
                gInfo.FillTileContainer(tile);
            }
        }
    }

    private void SetColor(GameObject tile, int x, int z)
    {
        MeshRenderer mr = tile.GetComponent<MeshRenderer>();
        // Чередование цветов
        Color color = ((x + z) % 2 == 0) ? _evenColor : _oddColor;
        mr.material.color = color;
    }

    public static int GetRandomTileNum() =>
        Random.Range(0, GridInfo.GetTileNum);
}
