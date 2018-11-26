using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    // music
    public AudioClip bg0;
    public AudioClip bg1;
    public AudioClip bg2;

    // volume to play at
    public float volume = 5;

    // the audio source
    public AudioSource[] sources;

    // Use this for initialization
    void Start()
    {
        // start the audio
        StartZero();
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
        sources[0].enabled = true;
        sources[1].enabled = false;
        sources[2].enabled = false;

        // Pick next track, wait for two cycles, then play next track
        if (nextTrack == 0)
        {
            Invoke("StartOne", bg0.length * 2.0f);
        }
        else if (nextTrack == 1)
        {
            Invoke("StartTwo", bg0.length * 2.0f);
        }
    }

    // start background 1
    public void StartOne()
    {
        // generate random number to decide what track to play next (0 - 1)
        float nextTrack = Mathf.Floor(Random.Range(0, 1));

        // set source0 to active and rest to inactive
        sources[0].enabled = false;
        sources[1].enabled = true;
        sources[2].enabled = false;

        // Pick next track, wait for two cycles, then play next track
        if (nextTrack == 0)
        {
            Invoke("StartZero", bg1.length * 2.0f);
        }
        else if (nextTrack == 1)
        {
            Invoke("StartTwo", bg1.length * 2.0f);
        }
    }

    // start background 2
    public void StartTwo()
    {
        // generate random number to decide what track to play next (0 - 1)
        float nextTrack = Mathf.Floor(Random.Range(0, 1));

        // set source0 to active and rest to inactive
        sources[0].enabled = false;
        sources[1].enabled = false;
        sources[2].enabled = true;

        // Pick next track, wait for two cycles, then play next track
        if (nextTrack == 0)
        {
            Invoke("StartOne", bg2.length * 2.0f);
        }
        else if (nextTrack == 1)
        {
            Invoke("StartZero", bg2.length * 2.0f);
        }
    }
}
