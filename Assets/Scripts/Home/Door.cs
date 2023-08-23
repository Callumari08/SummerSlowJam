using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    TransitionManager transition;
    TimeManager time;

    void Awake()
    {
        transition = FindObjectOfType<TransitionManager>();
        time = FindObjectOfType<TimeManager>();
    }

    public void Open()
    {
        if (Rent.rentPaid)
        {
            time.OnShiftStart.Invoke();
            Invoke("Close", transition.transitionDelay);
        }
        else
        {
            Debug.Log("You Haven't paid rent");
        }
    }

    void Close()
    {
        time.GoToWork();
        Rent.rentPaid = false;
    }
}
