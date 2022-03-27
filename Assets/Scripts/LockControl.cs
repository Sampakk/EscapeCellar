using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockControl : MonoBehaviour
{
    HUD hud;

    private int[] result, correctCombination;
    public static bool coroutineAllowed = true;
    public static bool isUsingPuzzle = false;
    public static bool isInteractable = false;

    public GameObject mainCamera;
    public GameObject lockCamera;
    public GameObject letter;

    Player player;

    bool isCompleted =false;
    public AudioSource CamAudio;
    public AudioClip RotationSound;
    public AudioClip LockOpenedSound;
    public float volume = 1f;
    void Start()
    {
        result = new int[] { 0, 0, 0 };
        correctCombination = new int[] { 4, 2, 0 };
        LockWheelRotate.Rotated += CheckResults;
        player = FindObjectOfType<Player>();
        hud = FindObjectOfType<HUD>();

        letter.SetActive(false);
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
        mainCamera.SetActive(false);
        lockCamera.SetActive(true);
        isUsingPuzzle = true;
        Player.stopMoving = true;
        hud.DisableUsePrompt();
    }

    void StopPuzzle()
    {
        mainCamera.SetActive(true);
        lockCamera.SetActive(false);
        Player.stopMoving = false;
        isUsingPuzzle = false;
        hud.EnableUsePrompt();
    }
    private void CheckResults(string wheelName, int number)
    {
        switch (wheelName)
        {
            case "wheel1":
                result[0] = number;
                break;
            case "wheel2":
                result[1] = number;
                break;
            case "wheel3":
                result[2] = number;
                break;
        }

        CamAudio.PlayOneShot(RotationSound, volume);
        if (result[0] == correctCombination[0] && result[1] == correctCombination[1] && result[2] == correctCombination [2])
        {
            Debug.Log("Opened!");
            CamAudio.PlayOneShot(LockOpenedSound, volume);
            //open chest code

            //try to get door
            Door door = GetComponent<Door>();
            if (door != null)
            {
                door.isOpen = true;

                isCompleted = true;
            }
        }
    }

    private void OnDestroy()
    {
        LockWheelRotate.Rotated -= CheckResults;
    }

    private void Update()
    {
        if (isInteractable && Input.GetKeyDown(KeyCode.E))
        {
            UsePuzzle();
            coroutineAllowed = true;
        }
        if (isUsingPuzzle && Input.GetKeyDown(KeyCode.Escape))
        {
            coroutineAllowed = false;
            StopPuzzle();

            if (isCompleted)
            {
                letter.SetActive(true);
                Destroy(this);
            }
        }

    }
}
