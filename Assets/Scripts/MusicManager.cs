using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] AudioSource soundObject;
    public void PlaySoundClip(AudioClip clip, Transform spawnPoint, float volume) 
    {
        Debug.Log("Playing");
        AudioSource audioSource = Instantiate(soundObject, spawnPoint.position, Quaternion.identity);
        audioSource.clip = clip;
        audioSource.volume = volume;
        audioSource.Play();
        Destroy(audioSource.gameObject, audioSource.clip.length);
    }
}
