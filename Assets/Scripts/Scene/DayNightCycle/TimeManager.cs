using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class TimeManager : MonoBehaviour
{

    public static TimeManager instance { get; private set; }

    public UnityEvent OnShiftEnd;
    public UnityEvent OnShiftStart;
    
    public float secondsBetweenIncrement;
    bool currentlyHome = true;

    static Time currentTime;
    static int currentDay;

    public TMP_Text infoText;

    public struct Time
    {
        public int Hour;
        public int Minute;
    }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (instance == null) {
            instance = this;
        } else {
            Destroy (gameObject);  
        }
        currentTime.Minute = 0;
        currentTime.Hour = 7;
    }

    void Update()
    {
        if (currentTime.Hour == 7 && currentTime.Minute == 0)
        {
            infoText.text = "";
        }
        else
        {
            infoText.text = ($"Day {currentDay}: {currentTime.Hour:00}:{currentTime.Minute:00}");
        }
    }

    public IEnumerator Clock()
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
