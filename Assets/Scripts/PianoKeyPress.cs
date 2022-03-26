using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PianoKeyPress : MonoBehaviour
{
    public static event Action<string> Pressed = delegate { };

    private bool coroutineAllowed;

    Player player;

    public static bool isInteractable = false;
    bool isUsingPuzzle = false;

    public Transform usePosition;
    public Transform cam;


    void Start()
    {
        coroutineAllowed = true;
        player = FindObjectOfType<Player>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isInteractable = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isInteractable = false;
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
    private IEnumerator PressKeyDown()
    {
        coroutineAllowed = false;

        for (int i = 0; i <= 11; i++)
        {
            gameObject.transform.Translate(0f, -0.01f, 0f);
            yield return new WaitForSeconds(0.01f);
        }

        for (int i = 0; i <= 11; i++)
        {
            gameObject.transform.Translate(0f, 0.01f, 0f);
            yield return new WaitForSeconds(0.01f);
        }

        coroutineAllowed = true;
      
        Pressed(name);
    }

    void InputListener()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && gameObject.name == "aKey")
        {
            if (coroutineAllowed) StartCoroutine("PressKeyDown");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && gameObject.name == "bKey")
        {
            if (coroutineAllowed) StartCoroutine("PressKeyDown");
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && gameObject.name == "cKey")
        {
            if (coroutineAllowed) StartCoroutine("PressKeyDown");
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && gameObject.name == "dKey")
        {
            if (coroutineAllowed) StartCoroutine("PressKeyDown");
        }

        if (Input.GetKeyDown(KeyCode.Alpha5) && gameObject.name == "eKey")
        {
            if (coroutineAllowed) StartCoroutine("PressKeyDown");
        }
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
        if (isUsingPuzzle)
        {
            InputListener();
        }
        
    }
}
