using UnityEngine;
using System.Collections;
using System;
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameState currentState = GameState.Idle;

    [SerializeField]
    private Dice dice;

    [SerializeField]
    private Player player;

    [SerializeField]
    private int MaxTurns = 10;

    public event Action<GameState> OnStateChanged;

    [SerializeField]
    private Board board;

    [SerializeField]
    private UIManager uiManager;

    private int currentTurn = 0;
    public GameState CurrentState => currentState;
    public int CurrentTurn => currentTurn;

    void Start()
    {
        player.MoveToTile(1);
        ChangeState(GameState.Idle);
        uiManager.UpdateTurn(currentTurn, MaxTurns);
        uiManager.UpdatePosition(player.CurrentTile);
        uiManager.UpdateDiceResult(0);
    }

    public void ChangeState(GameState newState)
    {
        if (currentState == newState)
        {
            return;
        }
        currentState = newState;

        Debug.Log("Game State: " + currentState);

        OnStateChanged?.Invoke(currentState);
    }

    private void CheckWin()
    {
        if(player.CurrentTile == 30)
        {
            ChangeState(GameState.Win);
            uiManager.ShowWin();
        }
        else if(currentTurn >= MaxTurns)
        {
            ChangeState(GameState.GameOver);
            uiManager.ShowGameOver();
        }
        else
        {
            ChangeState(GameState.Idle);
        }
    }
    public void StartRoll()
    {
        if (currentState != GameState.Idle)
        {
            return;
        }
        StartCoroutine(StartRollCoroutine());
    }

    private IEnumerator StartRollCoroutine(){
        currentTurn++;

        uiManager.UpdateTurn(currentTurn, MaxTurns);

        ChangeState(GameState.Rolling);

        int result = dice.Roll();

        uiManager.UpdateDiceResult(result);

        uiManager.ShowMessage($"Rolled {result}");

        ChangeState(GameState.Moving);

        yield return StartCoroutine(player.Move(result));

        uiManager.UpdatePosition(player.CurrentTile);

        yield return StartCoroutine(HandleSpecialTile());

        uiManager.UpdatePosition(player.CurrentTile);

        ChangeState(GameState.CheckWin);

        CheckWin();
        
    }
    private IEnumerator HandleSpecialTile()
    {
        TileType tileType = board.GetTileType(player.CurrentTile);

        switch (tileType)
        {
            case TileType.Boost:
                uiManager.ShowMessage("Boost! +2 spaces");
                yield return StartCoroutine(player.Move(2));
                break;

            case TileType.Trap:
                uiManager.ShowMessage("Trap! -3 spaces");
                yield return StartCoroutine(player.Move(-3));
                break;

            case TileType.Finish:
                uiManager.ShowMessage("Reached the finish!");
                break;

            case TileType.Normal:
                uiManager.ShowMessage($"Moved to tile {player.CurrentTile}");
                break;
        }
    }

    public void RestartGame()
    {
        currentTurn = 0;

        player.MoveToTile(1);

        uiManager.SetRollButtonInteractable(true);
        uiManager.UpdateTurn(currentTurn, MaxTurns);
        uiManager.UpdatePosition(player.CurrentTile);
        uiManager.UpdateDiceResult(0);

        uiManager.HideEndScreens();

        ChangeState(GameState.Idle);

        Debug.Log("Game restarted");
    }
}