using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BoardTile : MonoBehaviour
{
    public int tileIndex;

    [SerializeField]
    private TMP_Text tileNumberText;

    [SerializeField]
    private TileType tileType = TileType.Normal;

    public TileType Type => tileType;

    public void SetNumber(int number)
    {
        tileIndex = number;
        tileNumberText.text = tileIndex.ToString();
    }

    public void SetType(TileType type)
    {
        tileType = type;
    }
}