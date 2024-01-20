using UnityEngine;

public class PlayerInit
{
    public PlayerInit(Transform transform, out int tileNum)
    {
        tileNum = GridGenerator.GridInfo.GetTileNum / 2;
        Vector3 tilePos = GridGenerator.GridInfo.GetTilePos(tileNum);
        Debug.Log(tilePos);
        SetStartPlayerPos(transform, tilePos);
    }
    private void SetStartPlayerPos(Transform transform, Vector3 currTile)
    {
        float offset = transform.localScale.y / 2;
        transform.position = new Vector3(currTile.x, currTile.y + offset, currTile.z);
    }
}