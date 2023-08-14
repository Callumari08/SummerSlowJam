using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameTimeDateManager : MonoBehaviour
{
    public float secondsBetweenIncrement = 2.5f;
    [SerializeField] TextMeshProUGUI clock;

    [Header("Events")]
    [Space]
    public UnityEvent OnDay;
    [Space]
    public UnityEvent OnNight;

    public GameTimes dayTimes;
    public GameTimes nightTimes;
    public GameTime currentTime;
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
        DontDestroyOnLoad(gameObject);
        ConstructTimes();
        UpdateClockText();
        StartCoroutine(IncrementTime());

        SceneManager.sceneLoaded += OnSceneLoaded; // Subscribe to the sceneLoaded event
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // Unsubscribe to prevent memory leaks
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateClockText();
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
        clock.text = $"Day {currentTime.Day}: {currentTime.Hour:00}:{currentTime.Min:00}";
    }

    void CheckDayNightEvents()
    {
        isDay = IsTimeWithinRange(currentTime, dayTimes.StartTime, dayTimes.EndTime);

        if (isDay && !dayLastFrame)
        {
            OnDay.Invoke();
            print(isDay);
        }
        else if (!isDay && dayLastFrame)
        {
            OnNight.Invoke();
            print(isDay);
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