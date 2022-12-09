using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuOpcoes : MonoBehaviour
{

    public static float armazenaVolume;
    public AudioMixer mainMixer;
    public static bool som = true;

    public Slider slider;

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetVolume(float volume)
    {
        if (som == true)
        {
            armazenaVolume = volume;
            mainMixer.SetFloat("volume", volume);
        }
    }

    public void SetSound(bool setSound)
    {
        som = setSound;
        if (som == false)
        {
            mainMixer.SetFloat("volume", -80);
        }
    }

    void Update()
    {
        if (som == true)
        {
            SetVolume(armazenaVolume);
        }
        slider.value = armazenaVolume;
    }
}
