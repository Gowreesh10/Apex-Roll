using TMPro;
using UnityEngine;

public class Dice : MonoBehaviour
{

    [SerializeField]
    private TMP_Text diceResultText;

    [SerializeField]
    private Player player;

    public int Roll()
    {
        int result = Random.Range(1, 7);

        Debug.Log("Dice rolled: " + result);

        return result;
    }
    
    public void RollDice()
    {
        int result = Roll();
        diceResultText.text = $"Dice :  {result}";
        player.Move(result);
    }
}
