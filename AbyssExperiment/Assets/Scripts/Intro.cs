using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip PlayerResponse;
    public AudioClip Voice1;

    public void Start()
    {
        StartCoroutine(PlayAudio());
    }
    IEnumerator PlayAudio()
    {
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        audio.clip = PlayerResponse;
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        audio.clip = Voice1;
        audio.Play();
    }

}//Class
