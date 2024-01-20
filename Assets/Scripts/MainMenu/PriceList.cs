public class PriceList
{
    internal protected int[] LevelPrice = new int[LevelsPanel._LevelNum];
    int defaulValue = 80;
    public PriceList()
    {
        for (int i = 1; i < LevelPrice.Length; i++)
        {
            LevelPrice[i] = (defaulValue * i) + defaulValue;
        }
    }
}
