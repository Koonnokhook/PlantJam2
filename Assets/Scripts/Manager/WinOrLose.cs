using UnityEngine;

public class WinOrLose : MonoBehaviour
{
    public int maxSurvivalDays = 10;
    public GameTimeManaging gameTimeManager;
    private int currentSurvivalDays = 0;
    private bool hasWon = false;
    private bool hasLost = false;

    private void Start()
    {
        if (gameTimeManager != null)
        {
            gameTimeManager.OnDayChangedEvent += HandleDayChange;
        }
    }

    private void HandleDayChange(int currentDay)
    {
        if (!hasWon && !hasLost)
        {
            currentSurvivalDays = currentDay;

            if (currentSurvivalDays >= maxSurvivalDays)
            {
                WinGame();
            }
        }
    }

    private void WinGame()
    {
        Debug.Log("Congratulations! You've won the game!");
        hasWon = true;
    }

    private void LoseGame()
    {
        Debug.Log("Game Over. You've lost the game!");
        hasLost = true;
    }
}
