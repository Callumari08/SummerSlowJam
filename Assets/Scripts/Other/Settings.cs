using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public GameObject settingsPanel;

    public void OpenPanel() { settingsPanel.SetActive(true); }
    public void ClosePanel() { settingsPanel.SetActive(false); }
}
