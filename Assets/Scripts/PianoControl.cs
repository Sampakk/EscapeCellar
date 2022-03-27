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
    public AudioClip pianoWon;
    public float audiovolume = 0.5f;
    public static bool isInteractable = false;
    Player player;
    HUD hud;

    public static bool isUsingPuzzle = false;

    public Transform usePosition;
    public Transform cam;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        result = new string[] { "", "", "", "", "", "" };
        correctCombination = new string[] { "dKey", "eKey", "c#Key", "fKey", "dKey", "c#Key" };
        Array.Reverse(correctCombination);
        PianoKeyPress.Pressed += CheckResults;
        player = FindObjectOfType<Player>();
        hud = FindObjectOfType<HUD>();

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isInteractable = true;
            hud.EnableUsePrompt();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isInteractable = false;
            hud.DisableUsePrompt();
        }
    }

    void UsePuzzle()
    {
        player.transform.parent = usePosition;
        player.transform.localPosition = Vector3.zero;
        player.GetComponent<Player>().enabled = false;


        player.transform.LookAt(gameObject.transform.position);
        cam.localRotation = Quaternion.identity;

        isUsingPuzzle = true;
    }

    void StopPuzzle()
    {
        player.transform.parent = null;
        player.GetComponent<Player>().enabled = true;

        player.transform.rotation = Quaternion.identity;
        player.transform.rotation = Quaternion.Euler(0f, 270, 0);

        isUsingPuzzle = false;
    }

    private void CheckResults(string KeyName)
    {

        switch (KeyName)
        {
            case "c#Key":
                audioSource.PlayOneShot(pianoNote[0], audiovolume);
                break;
            case "dKey":
                audioSource.PlayOneShot(pianoNote[1], audiovolume);
                break;
            case "eKey":
                audioSource.PlayOneShot(pianoNote[2], audiovolume);
                break;
            case "fKey":
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
            audioSource.PlayOneShot(pianoWon, audiovolume);
            isInteractable = false;
            radio.gameObject.GetComponent<AudioSource>().enabled = true;

        }
    }

    private void OnDestroy()
    {
        PianoKeyPress.Pressed -= CheckResults;
    }

    private void Update()
    {
        if (isInteractable && Input.GetKeyDown(KeyCode.E))
        {
            UsePuzzle();
        }
        if (isUsingPuzzle && Input.GetKeyDown(KeyCode.Escape))
        {
            StopPuzzle();
        }
    }
}
