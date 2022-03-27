using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndKeyScript : MonoBehaviour
{
    Door openDoor;
    public GameObject door;
    private void Start()
    {
        openDoor = door.GetComponent<Door>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "EndDoor")
        {
            Destroy(gameObject);
            openDoor.isOpen = true;
        }
    }


}
