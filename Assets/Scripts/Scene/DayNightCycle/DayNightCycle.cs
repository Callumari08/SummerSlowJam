using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class DayNightCycle : MonoBehaviour
{
    public UnityEvent OnDay;
    public UnityEvent OnNight;

    public GameTime dayTimes;
    public GameTime nightTimes;
    public GameTime currentTime;
    public float secondsBetweenIncrement = 10f;

    [SerializeField] TextMeshProUGUI clock;
    bool dayLastFrame;

    public struct GameTime
    {
        public int Day;
        public int Hour;
        public int Min;
    }

    private void Awake()
    {
        // Initialize currentTime here...
        StartCoroutine(IncrementTime());
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
        // Add code to trigger day or night events based on the currentTime here
    }
}
