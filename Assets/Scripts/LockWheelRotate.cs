using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LockWheelRotate : MonoBehaviour
{
    public static event Action<string, int> Rotated = delegate { };

    

    private int numberShown;
    void Start()
    {
        numberShown = 0;
    }

    private IEnumerator RotateWheel()
    {
        LockControl.coroutineAllowed = false;

        for (int i = 0; i <= 11; i++)
        {
            transform.Rotate(0f, 0f, 3f);
            yield return new WaitForSeconds(0.01f);
        }

        LockControl.coroutineAllowed = true;
        numberShown += 1;

        if (numberShown > 9) numberShown = 0;

        Rotated(name, numberShown);
    }

    void InputListener()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && gameObject.name == "wheel1")
        {
            if (LockControl.coroutineAllowed) StartCoroutine("RotateWheel");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && gameObject.name == "wheel2")
        {
            if (LockControl.coroutineAllowed) StartCoroutine("RotateWheel");
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && gameObject.name == "wheel3")
        {
            if (LockControl.coroutineAllowed) StartCoroutine("RotateWheel");
        }
    }
    private void Update()
    {
        InputListener();
    }
}
