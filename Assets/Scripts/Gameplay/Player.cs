using UnityEngine;
using System.Collections;
public class Player : MonoBehaviour
{
    [SerializeField]
    private int currentTile = 1;

    [SerializeField]
    private Board board;

    [SerializeField]
    private float moveDelay = 0.2f;
    public int CurrentTile => currentTile;

    public IEnumerator Move(int spaces)
    {
        int targetTile = currentTile + spaces;
        if (targetTile > 30 || targetTile < 1)
        {
            yield break;
        }

        int direction = spaces > 0 ? 1 : -1;

        while(currentTile != targetTile)
        {
            currentTile += direction;
            MoveToTile(currentTile);
            yield return new WaitForSeconds(moveDelay);
        }
    }
    public void MoveToTile(int tileIndex)
    {
        currentTile = tileIndex;
        Vector3 targetPosition = board.GetTilePosition(tileIndex);

        transform.position = new Vector3(
            targetPosition.x,
            targetPosition.y,
            -1f
        );
    }
}