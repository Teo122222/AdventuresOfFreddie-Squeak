using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundAnim : MonoBehaviour
{
    [SerializeField] AudioClip sound;
    [SerializeField] AudioClip starSound = null;

    int counter = 0;

    AudioClip currentSound;

    private void Start()
    {
        currentSound = sound;
    }

    public void PlaySound(float volume)
    {
        if (currentSound != null) FindAnyObjectByType<MusicManager>().PlaySoundClip(currentSound, transform, volume);
        currentSound = starSound;
        counter++;
        if (counter % 4 == 0)
        {
            currentSound = sound;
        }
    }
}
