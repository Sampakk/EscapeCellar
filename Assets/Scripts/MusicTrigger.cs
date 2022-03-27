using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrigger : MonoBehaviour
{
    public AudioSource audio;
    public bool isTriggered = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EndKeyScript>() != null)
        {
            if (!isTriggered)
            {
                isTriggered = true;
                audio.Play();
            }
        }        
    }
}
