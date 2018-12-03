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
    float volumeStart = 1.0f;
    public float volumeMin = 0.2f;

    // bool for if volume is rising or decreasing
    bool volRise = false;

    // Use this for initialization
    void Start()
    {
        // get the start volume
        volumeStart = sources[0].GetComponent<AudioSource>().volume;
        currentAudio = sources[0];

        // start the audio
        StartZero();
    }

    // Update our music
    void Update()
    {
        // slowly decrease audio of current audio source
        if(volRise)
        {
            if (currentAudio.volume < volumeStart)
            {
                currentAudio.volume += 0.01f * Time.deltaTime;
            }
            else
            {
                volRise = false;
            }
        }
        else
        {
            if (currentAudio.volume > volumeMin)
            {
                currentAudio.volume -= 0.01f * Time.deltaTime;
            }
        }
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

        // set source0 to active and currentAudio source to inactive
        volRise = true;
        sources[0].enabled = true;
        
        // check if current audio is equal to sources[0] so we don't accidentally disable it
        if(sources[0] != currentAudio)
        {
            sources[0].volume = currentAudio.volume;
            currentAudio.enabled = false;
            currentAudio = sources[0];
        }

        // Pick next track, wait for five cycles, then play next track
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

        // set source1 to active and currentAudio source to inactive
        volRise = true;
        sources[1].enabled = true;
        
        // check if current audio is equal to sources[1] so we don't accidentally disable it
        if (sources[1] != currentAudio)
        {
            sources[1].volume = currentAudio.volume;
            currentAudio.enabled = false;
            currentAudio = sources[1];
        }


        // Pick next track, wait for five cycles, then play next track
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

        // set source1 to active and currentAudio source to inactive
        volRise = true;
        sources[2].enabled = true;
        
        // check if current audio is equal to sources[0] so we don't accidentally disable it
        if (sources[2] != currentAudio)
        {
            sources[2].volume = currentAudio.volume;
            currentAudio.enabled = false;
            currentAudio = sources[2];
        }

        // Pick next track, wait for five cycles, then play next track
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
