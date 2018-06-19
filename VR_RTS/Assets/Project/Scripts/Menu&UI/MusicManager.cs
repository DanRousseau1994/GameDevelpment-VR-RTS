using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] clips;

    public AudioSource Source;

    private void Awake()
    {
        StartCoroutine(PlayTrack());
    }

    private IEnumerator PlayTrack()
    {
        var cliptoplay = Random.Range(0, clips.Length);
        
        Source.clip = clips[cliptoplay];
        
        Source.Play();
        
        yield return new WaitForSeconds(clips[cliptoplay].length);

        StartCoroutine(PlayTrack());
    }
}
