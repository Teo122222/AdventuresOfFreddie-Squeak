using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingSoundAnim : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] AudioClip[] walkSounds;

    AudioClip currentSound;

    public void PlayFootStepSound()
    {
        currentSound = walkSounds[Random.Range(0,3)];
        GetComponent<AudioSource>().PlayOneShot(currentSound);
    }
}
