using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text turnText;
    [SerializeField]
    private TMP_Text positionText;
    [SerializeField]
    private TMP_Text diceResultText;

    [SerializeField]
    private TMP_Text winText;

    [SerializeField]
    private TMP_Text gameOverText;

    [SerializeField]
    private TMP_Text gameMessageText;

    [SerializeField]
    private GameObject restartButton;

    [SerializeField]
    private Button rollButton;

    [SerializeField]
    private GameManager gameManager;

    [SerializeField]
    private GameObject endGamePanel;

    public void Start()
    {
        endGamePanel.SetActive(false);
        winText.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);
        restartButton.SetActive(false);
    }
    public void UpdateTurn(int currentTurn, int maxTurns)
    {
        turnText.text = $"Turn: {currentTurn} / {maxTurns}";
    }

    public void UpdatePosition(int currentPosition)
    {
        positionText.text = $"Position: {currentPosition} / 30";
    }

    public void UpdateDiceResult(int result)
    {
        diceResultText.text = $"Last Roll: {result}";
    }

    public void ShowWin()
    {
        endGamePanel.SetActive(true);
        winText.gameObject.SetActive(true);
        restartButton.SetActive(true);

        ShowMessage("You reached the finish!");
    }

    public void ShowGameOver()
    {
        endGamePanel.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        restartButton.SetActive(true);

        ShowMessage("Game Over! You ran out of turns.");
    }

    public void HideEndScreens()
    {
        endGamePanel.SetActive(false);
        winText.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);
        restartButton.SetActive(false);

        ShowMessage("Roll the dice!");
    }

    public void SetRollButtonInteractable(bool interactable)
    {
        rollButton.interactable = interactable;
    }

    private void OnEnable()
    {
        gameManager.OnStateChanged += HandleStateChanged;
    }

    private void OnDisable()
    {
        gameManager.OnStateChanged -= HandleStateChanged;
    }

    private void HandleStateChanged(GameState state)
    {
        Debug.Log("UI received state: " + state);

        switch (state)
        {
            case GameState.Idle:
                SetRollButtonInteractable(true);
                break;

            case GameState.Rolling:
            case GameState.Moving:
            case GameState.CheckWin:
                SetRollButtonInteractable(false);
                break;

            case GameState.Win:
            case GameState.GameOver:
                SetRollButtonInteractable(false);
                break;
        }
    }

    public void ShowMessage(string message)
    {
        gameMessageText.text = message;
    }
}