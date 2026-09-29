using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField]
    private int boardSize = 30;

    [SerializeField]
    private int columns = 5;

    [SerializeField]
    private GameObject tilePrefab;

    private GameObject[] tiles;

    void Start()
    {
        tiles = new GameObject[boardSize + 1];

        for (int tileNumber = 1; tileNumber <= boardSize; tileNumber++)
        {
            int row = (tileNumber - 1) / columns;
            int column = (tileNumber - 1) % columns;

            if (row % 2 == 1)
            {
                column = columns - 1 - column;
            }

            GameObject tile = Instantiate(tilePrefab);

            tile.transform.position = new Vector3(column, row, 0);
            tile.transform.localScale = new Vector3(0.9f, 0.9f, 1f);

            BoardTile boardTile = tile.GetComponent<BoardTile>();
            boardTile.SetNumber(tileNumber);
            boardTile.SetType(DetermineTileType(tileNumber));
            tiles[tileNumber] = tile;
        }
    }

    public Vector3 GetTilePosition(int tileNumber)
    {
        return tiles[tileNumber].transform.position;
    }

    private TileType DetermineTileType(int tileIndex)
    {
        switch (tileIndex)
        {
            case 7:
                return TileType.Boost;

            case 14:
                return TileType.Trap;

            case 21:
                return TileType.Boost;

            case 25:
                return TileType.Trap;

            case 30:
                return TileType.Finish;

            default:
                return TileType.Normal;
        }
    }

    public TileType GetTileType(int tileNumber)
    {
        BoardTile boardTile = tiles[tileNumber].GetComponent<BoardTile>();

        return boardTile.Type;
    }
}