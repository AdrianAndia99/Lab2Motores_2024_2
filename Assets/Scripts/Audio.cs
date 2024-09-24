using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Audio : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider volumeSlider;
    public Slider masterSlider;
    public Slider SFXSlider;


    void Start()
    {
        float currentVolume1;
        float currentVolume2;
        float currentVolume3;

        audioMixer.GetFloat("Master", out currentVolume1);
        volumeSlider.value = currentVolume1;
        audioMixer.GetFloat("SFX", out currentVolume2);
        volumeSlider.value = currentVolume2;
        audioMixer.GetFloat("Volume", out currentVolume3);
        volumeSlider.value = currentVolume3;
    }

    public void OnSliderValueChanged(float value)
    {
        audioMixer.SetFloat("Master", value);
        audioMixer.SetFloat("SFX", value);
        audioMixer.SetFloat("Volume", value);

    }
}

