using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reacting : MonoBehaviour
{
    AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayClip(AudioClip clip)
    {
        audioSrc.PlayOneShot(clip, 0.5f);
    }
}
