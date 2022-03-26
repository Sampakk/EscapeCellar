using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PianoControl : MonoBehaviour
{
    private string[] result, correctCombination;
    AudioSource audioSource;
    public AudioClip[] pianoNote;
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
                audioSource.PlayOneShot(pianoNote[0], 0.7F);
                break;
            case "bKey":
                audioSource.PlayOneShot(pianoNote[1], 0.7F);
                break;
            case "cKey":
                audioSource.PlayOneShot(pianoNote[2], 0.7F);
                break;
            case "dKey":
                audioSource.PlayOneShot(pianoNote[3], 0.7F);
                break;
            case "eKey":
                audioSource.PlayOneShot(pianoNote[4], 0.7F);
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
            //Piano won code
        }
    }

    private void OnDestroy()
    {
        PianoKeyPress.Pressed -= CheckResults;
    }
}
