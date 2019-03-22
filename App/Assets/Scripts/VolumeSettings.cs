using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider volumeSlider;

    public void Start()
    {
        // For game initialization
        audioMixer.SetFloat("volume", PlayerPrefs.GetFloat("VolumeSettings", 0));

        // For volume settings page
        if (volumeSlider != null)
        {
            volumeSlider.value = PlayerPrefs.GetFloat("VolumeSettings", 0);
        }
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("VolumeSettings", volume);
    }
}
