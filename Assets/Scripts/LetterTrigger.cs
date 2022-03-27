using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterTrigger : MonoBehaviour
{
    public AudioClip footsteps;
    public Transform footstepsPos;

    public GameObject disableOnUse;
    public Door openOnUse;

    public void UseTrigger()
    {
        AudioSource.PlayClipAtPoint(footsteps, footstepsPos.position);

        disableOnUse.SetActive(false);
        openOnUse.isOpen = true;

        Destroy(this);
    } 
}
