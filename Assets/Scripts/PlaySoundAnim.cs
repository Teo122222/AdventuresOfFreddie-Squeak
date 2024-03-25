using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundAnim : MonoBehaviour
{
    [SerializeField] AudioClip sound;
    [SerializeField] AudioClip starSound = null;

    public void PlaySound(float volume)
    {
        FindAnyObjectByType<MusicManager>().PlaySoundClip(sound, transform, volume);
        if (starSound != null)
        {
            sound = starSound;
        }
    }
}
