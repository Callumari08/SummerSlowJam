using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class TimeManager : MonoBehaviour
{
    public UnityEvent OnShiftEnd;
    public UnityEvent OnShiftStart;
    
    public float secondsBetweenIncrement;
    bool currentlyHome;

    static Time currentTime;
    static int currentDay;

    public struct Time
    {
        public int Hour;
        public int Minute;
    }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        currentTime.Minute = 0;
        currentTime.Hour = 7;
        StartCoroutine(Clock());
    }

    IEnumerator Clock()
    {
        if (currentlyHome == false)
        {
            currentTime.Minute += 10;

            if (currentTime.Minute > 50)
            {
                currentTime.Minute = 0;
                currentTime.Hour += 1;
            }

            if (currentTime.Hour > 18) currentTime.Hour = 0;

            if (currentTime.Hour == 18)
            {
                OnShiftEnd.Invoke();
                currentTime.Minute = 0;
                currentTime.Hour = 7;
                currentlyHome = true;
            }

            yield return new WaitForSeconds(secondsBetweenIncrement);
            Debug.Log(currentTime.Hour + ":" + currentTime.Minute);
            StartCoroutine(Clock());
        }

        else yield break;
    }

    public void GoToWork()
    {
        OnShiftStart.Invoke();
        currentDay += 1;
        currentlyHome = false;
    }
}
