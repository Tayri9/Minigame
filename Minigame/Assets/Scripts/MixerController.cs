using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MixerController : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    string mixer = "";
    public void SetVolume(float sliderValue)
    {
        audioMixer.SetFloat(mixer, Mathf.Log10(sliderValue)*20);
    }

    public void SetMixer(string mixer)
    {
        this.mixer = mixer;
    }
}
