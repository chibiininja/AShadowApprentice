using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    [SerializeField]
    private Toggle volumeToggle;
    [SerializeField]
    private Slider volumeSlider;
    private float savedVolume;

    public void UpdateVolumeSlider()
    {
        volumeToggle.isOn = (volumeSlider.value == 0f) ? false : true;
        AudioListener.volume = volumeSlider.value;
    }

    public void UpdateVolumeTrigger()
    {
        if (!volumeToggle.isOn)
        {
            savedVolume = volumeSlider.value;
            volumeSlider.value = 0f;
        }
        else if (savedVolume == 0f)
        {
            savedVolume = 0.0001f;
            volumeSlider.value = savedVolume;
        }
        else
        {
            volumeSlider.value = savedVolume;
        }

    }
}
