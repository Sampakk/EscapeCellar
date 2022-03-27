using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndKeyScript : MonoBehaviour
{
    Door openDoor;
    public GameObject door;
    public AudioSource CameraSource;
    public AudioClip ScaryEndNoise;
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
            StartCoroutine(ScaryEnd());
        }
    }
     IEnumerator ScaryEnd()
    {
        Debug.Log("Works");
        yield return new WaitForSeconds(5);
        Debug.Log("Works2");
        CameraSource.PlayOneShot(ScaryEndNoise, 1f);
        yield return new WaitForSeconds(2);
        Debug.Log("Works3");
        Application.Quit();

    } 

}
