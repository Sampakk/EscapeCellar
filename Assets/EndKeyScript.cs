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
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Door")
        {
            Destroy(gameObject);
            openDoor.isOpen = true;
        }
    }

   
}
