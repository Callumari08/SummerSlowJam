using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public void Open()
    {
        if (Rent.rentPaid)
        {
            TimeManager TM = FindObjectOfType<TimeManager>();
            Rent.rentPaid = false;
            TM.GoToWork();
            TM.StartCoroutine(TM.Clock());
        }
        else
        {
            Debug.Log("You Haven't paid rent");
        }
    }
}
