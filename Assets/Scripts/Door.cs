using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform door;
    public bool isOpen;
    public bool isChest;
    public float openingSpeed = 5f;
    public float openingAngle = 90f;

    Vector3 closedEulers;

    // Start is called before the first frame update
    void Start()
    {
        closedEulers = door.localEulerAngles;
        if (isOpen) door.localRotation = Quaternion.Euler(closedEulers.x, closedEulers.y + openingAngle, closedEulers.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen)
        {
            if (isChest)
            {
                door.localRotation = Quaternion.Slerp(door.localRotation, Quaternion.Euler(closedEulers.x + openingAngle, closedEulers.y, closedEulers.z), openingSpeed * Time.deltaTime);

            }
            else 
            { 
                door.localRotation = Quaternion.Slerp(door.localRotation, Quaternion.Euler(closedEulers.x, closedEulers.y + openingAngle, closedEulers.z), openingSpeed * Time.deltaTime); 
            }
        }
        else
        {
            door.localRotation = Quaternion.Slerp(door.localRotation, Quaternion.Euler(closedEulers), openingSpeed * Time.deltaTime);
        }
    }
}
