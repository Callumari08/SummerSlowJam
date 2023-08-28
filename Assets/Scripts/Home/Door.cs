using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    TransitionManager transition;
    TimeManager time;
    bool hasOpened = false;

    public UnityEvent OnOpen;
    public GameObject AlertPanel;

    void Awake()
    {
        transition = FindObjectOfType<TransitionManager>();
        time = FindObjectOfType<TimeManager>();
    }

    public void Open()
    {
        if (hasOpened == false)
        {
            if (Rent.rentPaid)
            {
                hasOpened = true;
                OnOpen.Invoke();
                Invoke("Close", transition.transitionDelay);
            }
            else
            {
                AlertPanel.SetActive(true);
                Invoke("EndAlert", 2);
            }
        }
    }

    void EndAlert()
    {
        AlertPanel.SetActive(false);
    }

    void Close()
    {
        time.GoToWork();
        Rent.rentPaid = false;
        hasOpened = false;
    }
}
