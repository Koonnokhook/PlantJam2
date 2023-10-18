using UnityEngine;
using TMPro;

public class GameTimeManaging : MonoBehaviour
{
    public FarmingSystem plantFarming;

    public delegate void OnDayChanged(int currentDay);
    public event OnDayChanged OnDayChangedEvent;

    public TextMeshProUGUI dayText;
    public TextMeshProUGUI timeText;

    private float timePassed = 0;
    private int currentDay = 1;
    public int startingHour = 6;
    public int startingMinute = 0;
    private float realTimePerGameDay = 360; 

    private int currentHour;
    private int currentMinute;

    private void Start()
    {
        currentHour = startingHour;
        currentMinute = startingMinute;
        UpdateDayAndTimeUI();
    }

    private void Update()
    {
        timePassed += Time.deltaTime;

        if (timePassed >= realTimePerGameDay)
        {
            timePassed = 0;
            currentDay++;

            OnDayChangedEvent?.Invoke(currentDay);
            UpdateDayAndTimeUI();
        }

        currentMinute += 1;
        if (currentMinute >= 60)
        {
            currentMinute = 0;
            currentHour += 1;

            if (currentHour >= 24)
            {
                currentHour = 0;
            }
        }
    }

    private void UpdateDayAndTimeUI()
    {
        dayText.text = "Day " + currentDay.ToString();
        timeText.text = "Time: " + FormatTime(currentHour, currentMinute);
    }

    private string FormatTime(int hour, int minute)
    {
        string hourString = hour < 10 ? "0" + hour.ToString() : hour.ToString();
        string minuteString = minute < 10 ? "0" + minute.ToString() : minute.ToString();

        return hourString + ":" + minuteString;
    }
}
