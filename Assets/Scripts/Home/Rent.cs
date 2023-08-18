using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rent : MonoBehaviour
{
    public float rentAmount;
    public bool rentPaid;

    public void Pay()
    {
        if (!rentPaid)
        {
            if (Money.Current >= rentAmount)
            {
                Money.Current -= rentAmount;
                rentPaid = true;
            }
            else
            {
                Debug.Log("You're broke");
            }
        }
    }
}
