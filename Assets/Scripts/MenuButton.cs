using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    public AudioSource audiosource;
    public AudioClip click;
    public GameObject Panel;
    public float audiovolume = 1f;



   

    public void PressButton()
    {
        audiosource.PlayOneShot(click, audiovolume);
        if(Panel != null)
        {
            Panel.SetActive(true);
        }
        else
        {
            Panel.SetActive(false);
        }
    }
    
   
}

