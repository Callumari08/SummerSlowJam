using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    public GameObject settingsPanel;
    public Slider volumeSlider;
    public AudioMixer mix;
    bool isFullscreen;

    void Start() { settingsPanel.SetActive(false); }
    public void OpenPanel() { settingsPanel.SetActive(true); }
    public void ClosePanel() { settingsPanel.SetActive(false); }

    public void OnFullToggleChange(bool tickOn)
    {
        if (tickOn)
        {
            isFullscreen = true;
            Debug.Log("fullscreen on");
        }
        else
        {
            isFullscreen = false;
            Debug.Log("fullscreen off");
        }
    }

    void Update()
    {
        Screen.fullScreen = isFullscreen;
    }

    public void ChangeVolume()
    {
        mix.SetFloat("Vol", volumeSlider.value);
    }
}
