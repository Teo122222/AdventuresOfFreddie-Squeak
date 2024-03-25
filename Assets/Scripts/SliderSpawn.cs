using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SliderSpawn : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] Sprite SoundOn;
    [SerializeField] Sprite SoundOff;
    [SerializeField] Image soundIcon;

    Slider slider;
    void Start()
    {
        float value;
        mixer.GetFloat("masterVolume", out value);
        slider = GetComponent<Slider>();
        slider.value = Mathf.Pow(10, (value/20f));
        
    }

    void Update()
    {
        if (slider.value == slider.minValue)
        {
            soundIcon.sprite = SoundOff;
        }
        else
        {
            soundIcon.sprite = SoundOn;
        }
    }
}
