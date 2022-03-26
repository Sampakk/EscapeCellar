using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
    Player player;
    Interactables interactables;
    public TextMeshProUGUI noteText;
    public Image noteImage;
    public TextMeshProUGUI interactText;

    // Start is called before the first frame update
    void Start()
    {
        interactables = FindObjectOfType<Interactables>();
        player = FindObjectOfType<Player>();

        noteText.enabled = false;
        noteImage.enabled = false;
        interactText.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EnableNote(string text)
    {
        player.enabled = false;

        interactText.enabled = false;
        noteText.enabled = true;
        noteText.text = text;
    }
    public void EnableNotePicture(string text, Sprite image)
    {
        player.enabled = false;

        interactText.enabled = false;
        noteText.enabled = true;
        noteImage.enabled = true;
        noteText.text = text;
        noteImage.sprite = image;
    }

    public void CloseNote()
    {
        player.enabled = true;

        noteText.enabled = false;
        noteImage.enabled = false;

    }

    public void EnableUsePrompt()
    {
        interactText.enabled = true;
    }

    public void DisableUsePrompt()
    {
        interactText.enabled = false;
    }
}
