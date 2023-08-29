using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour
{
    public Transform panel;

    public void OpenPanel()
    {
        Cursor.lockState = CursorLockMode.None;
        panel.gameObject.SetActive(true);
    }

    public void ClosePanel()
    {
        Cursor.lockState = CursorLockMode.Locked;
        panel.gameObject.SetActive(false);
    }
}
