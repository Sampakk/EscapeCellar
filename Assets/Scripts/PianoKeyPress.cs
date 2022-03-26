using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PianoKeyPress : MonoBehaviour
{
    public static event Action<string> Pressed = delegate { };

    private bool coroutineAllowed;

   


    void Start()
    {
        coroutineAllowed = true;
        
    }



   
    private IEnumerator PressKeyDown()
    {
        coroutineAllowed = false;

        for (int i = 0; i <= 9; i++)
        {
            gameObject.transform.Translate(0f, 0f, -0.01f);
            yield return new WaitForSeconds(0.01f);
        }

        for (int i = 0; i <= 9; i++)
        {
            gameObject.transform.Translate(0f, 0f, +0.01f);
            yield return new WaitForSeconds(0.01f);
        }

        coroutineAllowed = true;
      
        Pressed(name);
    }

    void InputListener()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && gameObject.name == "c#Key")
        {
            if (coroutineAllowed) StartCoroutine("PressKeyDown");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && gameObject.name == "dKey")
        {
            if (coroutineAllowed) StartCoroutine("PressKeyDown");
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && gameObject.name == "eKey")
        {
            if (coroutineAllowed) StartCoroutine("PressKeyDown");
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && gameObject.name == "fKey")
        {
            if (coroutineAllowed) StartCoroutine("PressKeyDown");
        }


    }
    private void Update()
    {
        
        if (PianoControl.isUsingPuzzle)
        {
            InputListener();
        }
        
    }
}
