using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mic : MonoBehaviour
{
    Slider sliderBar;
    AudioClip clip;
    public AudioSource reproduction;

    void Start()
    {
        sliderBar = GetComponent<Slider>();
        clip = Microphone.Start(Microphone.devices[0], true, 1, 44100);

        
        reproduction.clip = clip;
        reproduction.Play();
        
    }

    void Update()
    {
        sliderBar.value = clip.frequency;
    }
}
