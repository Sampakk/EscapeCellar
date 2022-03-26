using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Begin : MonoBehaviour
{
    public AudioSource audiosource;
    public AudioClip pressbegin;
    public Animator animator;
    public float audiovolume = 1f;
    


    void Start()
    {
        
    }

    public void StartGame()
    {
        audiosource.PlayOneShot(pressbegin, audiovolume);
        FadeToLevel(1);
       
        StartCoroutine(WaitForStart());
    }

    IEnumerator WaitForStart()
    {
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(1);
    }
    public void FadeToLevel(int levelIndex)
    {
        animator.SetTrigger("fade");
    }
}

