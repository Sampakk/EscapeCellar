using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : MonoBehaviour
{
    HUD hud;

    public string noteText;
    public Sprite noteImage;

    public bool useable = false;
    bool isUsingNote = false;

    // Start is called before the first frame update
    void Start()
    {
        hud = FindObjectOfType<HUD>();
    }

    void Update()
    {
        if (useable && Input.GetKeyDown(KeyCode.E))
        {
            UseNote();
        }
        if(isUsingNote && Input.GetKeyDown(KeyCode.Escape))
        {
            hud.CloseNote();
            isUsingNote = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            useable = true;
            hud.EnableUsePrompt();
        }

    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            useable = true;
            hud.EnableUsePrompt();
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") 
        { 
            useable = false;
            hud.DisableUsePrompt();
        }
    }

    void UseNote()
    {
        isUsingNote = true;

        if (noteImage != null) hud.EnableNotePicture(noteText, noteImage);
        else hud.EnableNote(noteText);

        //Try to activate letter trigger
        LetterTrigger trigger = GetComponent<LetterTrigger>();
        if (trigger != null) trigger.UseTrigger();
    }

}
