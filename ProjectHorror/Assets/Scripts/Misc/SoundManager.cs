using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static void PlaySound(AudioSource audioSource)
    {
        audioSource.Play();
    }

    public static void PauseSound(AudioSource audioSource)
    {
        audioSource.Pause();
    }

    public static void UnPauseSound(AudioSource audioSource)
    {
        audioSource.UnPause();
    }

    public static void StopSound(AudioSource audioSource)
    {
        audioSource.Stop();
    }
}
