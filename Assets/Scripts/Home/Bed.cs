using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour
{
    public GameObject panel;

    public void OpenPanel()
    {
        Cursor.lockState = CursorLockMode.None;
        panel.SetActive(true);
    }

    public void ClosePanel()
    {
        Cursor.lockState = CursorLockMode.Locked;
        panel.SetActive(false);
    }
}
