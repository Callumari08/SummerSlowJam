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
                Debug.Log("You Haven't paid rent");
            }
        }
    }

    void Close()
    {
        time.GoToWork();
        Rent.rentPaid = false;
        hasOpened = false;
    }
}
