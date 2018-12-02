using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{

    // sound effects
    public AudioClip creak;
    public AudioClip newClue;
    public AudioClip strangeSound;

    // volume to play at
    public float volume = 5;

    // the audio source
    private AudioSource source;

    // Use this for initialization
    void Start()
    {
        // get the audio source
        source = gameObject.GetComponent<AudioSource>();
    }

    // play door creaking
    public void PlayCreak()
    {
        source.PlayOneShot(creak, volume);
    }

    // play new clue sound (writing something in journal)
    public void PlayNewClue()
    {
        source.PlayOneShot(newClue, volume);
    }

    // play strange sound
    public void PlayStrangeSound()
    {
        source.PlayOneShot(strangeSound, volume);
    }
}
