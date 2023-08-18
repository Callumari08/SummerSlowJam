using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Rent rent;

    public void Open()
    {
        if (rent.rentPaid)
        {
            TimeManager TM = FindObjectOfType<TimeManager>();
            rent.rentPaid = false;
            TM.GoToWork();
            TM.StartCoroutine(TM.Clock());
        }
        else
        {
            Debug.Log("You Haven't paid rent");
        }
    }
}
