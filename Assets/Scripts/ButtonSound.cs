using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    [SerializeField] AudioClip sound;
    [SerializeField] float volume = 1f;

    public void PlayButtonSound()
    {
        FindAnyObjectByType<MusicManager>().PlaySoundClip(sound, transform, volume);
    }
}
