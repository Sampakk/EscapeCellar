using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Begin : MonoBehaviour
{
    public AudioSource audiosource;
    public AudioClip pressbegin;
    
    public float audiovolume = 1f;
    private bool begun = false;


    void Start()
    {
        
    }

    public void StartGame()
    {
        audiosource.PlayOneShot(pressbegin, audiovolume);
        begun = true;
        StartCoroutine(WaitForStart());
    }

    IEnumerator WaitForStart()
    {
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(1);
    }
}

