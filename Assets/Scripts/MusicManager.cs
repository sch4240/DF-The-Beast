using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    // music
    public AudioClip bg0;
    public AudioClip bg1;
    public AudioClip bg2;

    // the audio source
    public AudioSource[] sources;

    // current audio source
    private AudioSource currentAudio;

    // volume at start
    float volumeStart = 1;

    // Use this for initialization
    void Start()
    {
        // get the start volume
        volumeStart = sources[0].GetComponent<AudioSource>().volume;

        // start the audio
        StartZero();
    }

    // Update our music
    void Update()
    {
        // slowly decrease audio of current audio source
        currentAudio.volume -= 0.01f * Time.deltaTime;
    }


    // Cancel Coroutines
    public void Cancel()
    {
        CancelInvoke();
    }

    // start background 0
    public void StartZero()
    {
        // generate random number to decide what track to play next (0 - 1)
        float nextTrack = Mathf.Floor(Random.Range(0, 1));

        // set source0 to active and rest to inactive
        for (int i = 0; i < sources.Length; i++)
        {
            if(i == 0)
            {
                sources[i].enabled = true;
                currentAudio = sources[i];
                currentAudio.volume = volumeStart;
            }
            else
            {
                sources[i].enabled = false;
            }
        }

        // Pick next track, wait for two cycles, then play next track
        if (nextTrack == 0)
        {
            Invoke("StartOne", bg0.length * 5.0f);
        }
        else if (nextTrack == 1)
        {
            Invoke("StartTwo", bg0.length * 5.0f);
        }
    }

    // start background 1
    public void StartOne()
    {
        // generate random number to decide what track to play next (0 - 1)
        float nextTrack = Mathf.Floor(Random.Range(0, 1));

        // set source1 to active and rest to inactive
        for (int i = 0; i < sources.Length; i++)
        {
            if (i == 1)
            {
                sources[i].enabled = true;
                currentAudio = sources[i];
                currentAudio.volume = volumeStart;
            }
            else
            {
                sources[i].enabled = false;
            }
        }

        // Pick next track, wait for two cycles, then play next track
        if (nextTrack == 0)
        {
            Invoke("StartZero", bg1.length * 5.0f);
        }
        else if (nextTrack == 1)
        {
            Invoke("StartTwo", bg1.length * 5.0f);
        }
    }

    // start background 2
    public void StartTwo()
    {
        // generate random number to decide what track to play next (0 - 1)
        float nextTrack = Mathf.Floor(Random.Range(0, 1));

        // set source2 to active and rest to inactive
        for (int i = 0; i < sources.Length; i++)
        {
            if (i == 2)
            {
                sources[i].enabled = true;
                currentAudio = sources[i];
                currentAudio.volume = volumeStart;
            }
            else
            {
                sources[i].enabled = false;
            }
        }

        // Pick next track, wait for two cycles, then play next track
        if (nextTrack == 0)
        {
            Invoke("StartOne", bg2.length * 5.0f);
        }
        else if (nextTrack == 1)
        {
            Invoke("StartZero", bg2.length * 5.0f);
        }
    }
}
