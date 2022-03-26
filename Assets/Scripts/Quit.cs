using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Quit : MonoBehaviour
{
    public AudioSource audiosource;
    public AudioClip click;

    public float audiovolume = 1f;



    void Start()
    {

    }

    public void QuitGame()
    {
        audiosource.PlayOneShot(click, audiovolume);
        Application.Quit();

    }

   
}

