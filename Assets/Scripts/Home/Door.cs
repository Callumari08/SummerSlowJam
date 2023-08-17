using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public void Open()
    {
        TimeManager TM = FindObjectOfType<TimeManager>();
        TM.GoToWork();
        TM.StartCoroutine(TM.Clock());
    }
}
