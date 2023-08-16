using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TimeDateManager : MonoBehaviour
{
    public float secondsBetweenIncrement = 2.5f;
    [SerializeField] TextMeshProUGUI clock;

    [Header("Events")]
    [Space]
    public UnityEvent OnDay;
    [Space]
    public UnityEvent OnNight;

    public static GameTimes dayTimes;
    public static GameTimes nightTimes;
    public static GameTime currentTime;
    [HideInInspector] public bool isDay;

    bool dayLastFrame;

    public struct GameTime
    {
        public int Day;
        public int Hour;
        public int Min;
    }

    public struct GameTimes
    {
        public GameTime StartTime;
        public GameTime EndTime;
    }

    private void Awake()
    {
        ConstructTimes();
        UpdateClockText();
        StartCoroutine(IncrementTime());
    }

    IEnumerator IncrementTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(secondsBetweenIncrement);

            currentTime.Min += 10;

            while (currentTime.Min >= 60)
            {
                currentTime.Hour++;
                currentTime.Min -= 60;
            }

            while (currentTime.Hour >= 24)
            {
                currentTime.Day++;
                currentTime.Hour -= 24;
            }

            UpdateClockText();
            CheckDayNightEvents();
        }
    }

    void UpdateClockText()
    {
        if (clock) 
            clock.text = $"Day {currentTime.Day}: {currentTime.Hour:00}:{currentTime.Min:00}";
    }

    void CheckDayNightEvents()
    {
        isDay = IsTimeWithinRange(currentTime, dayTimes.StartTime, dayTimes.EndTime);

        if (isDay && !dayLastFrame)
        {
            OnDay.Invoke();
        }
        else if (!isDay && dayLastFrame)
        {
            OnNight.Invoke();
        }

        dayLastFrame = isDay;
    }

    bool IsTimeWithinRange(GameTime currentTime, GameTime startTime, GameTime endTime)
    {
        if (currentTime.Hour > startTime.Hour && currentTime.Hour < endTime.Hour)
        {
            return true;
        }
        else if (currentTime.Hour == startTime.Hour && currentTime.Min >= startTime.Min)
        {
            return true;
        }
        else if (currentTime.Hour == endTime.Hour && currentTime.Min <= endTime.Min)
        {
            return true;
        }

        return false;
    }

    void ConstructTimes()
    {
        dayTimes.StartTime.Hour = 7;
        dayTimes.StartTime.Min = 30;
        dayTimes.EndTime.Hour = 18;
        dayTimes.EndTime.Min = 30;

        nightTimes.StartTime.Hour = 18;
        nightTimes.StartTime.Min = 31;
        nightTimes.EndTime.Hour = 7;
        nightTimes.EndTime.Min = 29;
    }
}