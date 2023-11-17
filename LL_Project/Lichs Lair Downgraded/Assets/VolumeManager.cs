using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{

    public Slider MusicSlider;
    public Slider SoundsSlider;

    public float MinVolume = -80f;
    public float MaxVolume = 0f;

    public float currentMusicVolume;

    public AudioMixer audioMixer;


    // Start is called before the first frame update
    void Start()
    {
        
        MusicSlider.value = 0;

        SoundsSlider.value = MaxVolume;

    }

    // Update is called once per frame
    void Update()
    {
       currentMusicVolume = MusicSlider.value;
       MusicSlider.minValue = -80f;
       MusicSlider.maxValue = 0;

    }

    public void SetSoundVolume(float soundLevel)
    {
        audioMixer.SetFloat("musicVol", soundLevel);
    }
}
