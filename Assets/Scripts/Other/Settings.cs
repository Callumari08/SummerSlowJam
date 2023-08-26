using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class Settings : MonoBehaviour
{
    public GameObject settingsPanel;
    public Slider volumeSlider;
    public TMP_Text volumeText;
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
        volumeText.text = $"Volume {Mathf.Round(volumeSlider.value * 100)}%";
    }

    public void ChangeVolume()
    {
        mix.SetFloat("Vol", Mathf.Log10(volumeSlider.value)*20);
    }
}
