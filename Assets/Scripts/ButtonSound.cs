using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    [SerializeField] AudioClip buttonHoverSound;
    [SerializeField] AudioClip buttonClickSound;

    [SerializeField] float volume = 1f;

    public void PlayButtonSound()
    {
        FindAnyObjectByType<MusicManager>().PlaySoundClip(buttonClickSound, transform, volume);
    }

    public void OnPointerEnter( ) {
	    FindAnyObjectByType<MusicManager>().PlaySoundClip(buttonHoverSound,transform, volume);
	}
}
