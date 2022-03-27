using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrigger : MonoBehaviour
{
    public AudioSource audio;
    public bool isTriggered = false;
    public AudioSource CameraSource;
    public AudioClip ScaryEndNoise;
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
        if (other.GetComponentInChildren<EndKeyScript>() != null)
        {
            if (!isTriggered)
            {
                isTriggered = true;
                audio.Play();
                StartCoroutine(ScaryEnd());
            }
            
           
        }  
        
        
    }
    
    IEnumerator ScaryEnd()
            {
                Debug.Log("Works");
                yield return new WaitForSeconds(11);
                Debug.Log("Works2");
                CameraSource.PlayOneShot(ScaryEndNoise, 1f);
                yield return new WaitForSeconds(2);
                Debug.Log("Works3");
                Application.Quit();

            }       
}
