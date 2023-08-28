using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bed : MonoBehaviour
{
    Transform bedUI;
    public UnityEvent OnOpen;

    public void Start()
    {
        bedUI = GameObject.Find("BedUI").transform;
        ClosePanel();
    }

    public void OpenPanel()
    {
        Cursor.lockState = CursorLockMode.None;
        bedUI.gameObject.SetActive(true);
        OnOpen.Invoke();
    }

    public void ClosePanel()
    {
        Cursor.lockState = CursorLockMode.Locked;
        bedUI.gameObject.SetActive(false);
    }
}
