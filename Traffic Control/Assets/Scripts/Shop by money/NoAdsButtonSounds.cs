using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class NoAdsButtonSounds : MonoBehaviour
{
    public void PressedButton()
    {
        PlayButtonSound();

    }

    private void PlayButtonSound()
    {
        if (PlayerPrefs.GetString("music") != "No")
            GetComponent<AudioSource>().Play();
    }

    public void DefaultButton()
    {
        PlayButtonSound();
    }
}