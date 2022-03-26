using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PianoControl : MonoBehaviour
{
    private string[] result, correctCombination;
    public GameObject radio;
    AudioSource audioSource;
    public AudioClip[] pianoNote;
    public float audiovolume = 0.5f;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        result = new string[] { "", "", "", "", "", "" };
        correctCombination = new string[] { "aKey", "bKey", "cKey", "dKey", "eKey", "aKey" };
        Array.Reverse(correctCombination);
        PianoKeyPress.Pressed += CheckResults;
        

    }

    
    private void CheckResults(string KeyName)
    {

        switch (KeyName)
        {
            case "aKey":
                audioSource.PlayOneShot(pianoNote[0], audiovolume);
                break;
            case "bKey":
                audioSource.PlayOneShot(pianoNote[1], audiovolume);
                break;
            case "cKey":
                audioSource.PlayOneShot(pianoNote[2], audiovolume);
                break;
            case "dKey":
                audioSource.PlayOneShot(pianoNote[3], audiovolume);
                break;
        }

        result[5] = result[4];
        result[4] = result[3];
        result[3] = result[2];
        result[2] = result[1];
        result[1] = result[0];
        result[0] = KeyName;



        if (result[0] == correctCombination[0] && result[1] == correctCombination[1] && result[2] == correctCombination[2] && result[3] == correctCombination[3] && result[4] == correctCombination[4] && result[5] == correctCombination[5])
        {
            Debug.Log("Opened!");
            PianoKeyPress.isInteractable = false;
            radio.gameObject.GetComponent<AudioSource>().enabled = true;

        }
    }

    private void OnDestroy()
    {
        PianoKeyPress.Pressed -= CheckResults;
    }
}
