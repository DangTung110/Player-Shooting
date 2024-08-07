using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSetting : MonoBehaviour
{
    [SerializeField] private AudioSource audio;
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider slider;
    private void Start()
    {
        audio.Play();
        slider.value = PlayerPrefs.GetFloat("VolumeMusic");
        SetMusicVolume();
    }
    public void SetMusicVolume()
    {
        float volume = slider.value;
        audioMixer.SetFloat("Volume", volume * 20f - 30f);
        PlayerPrefs.SetFloat("VolumeMusic", volume);
    }
}