using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public AudioClip[] musicPlays;
    public int musicOrder;

    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = musicPlays[musicOrder];
        audioSource.loop = true;
        audioSource.Play();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PauseMusic()
    {
        audioSource.Pause();
    }

    public void UnPauseMusic()
    {
        audioSource.UnPause();
    }
}
