using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
    Player player;
    public Image backgroundImage;
    public TextMeshProUGUI noteText;
    public Image noteImage;
    public TextMeshProUGUI interactText;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();

        backgroundImage.enabled = false;
        noteText.enabled = false;
        noteImage.enabled = false;
        interactText.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if (player.isLookingAtNote)
            {
                interactText.enabled = true;
            }
            else interactText.enabled = false;
        }
    }

    public void EnableNote(string text)
    {
        noteText.enabled = true;
        noteText.text = text;
    }
    public void EnableNotePicture(string text, Sprite image)
    {
        noteText.enabled = true;
        noteImage.enabled = true;
        noteText.text = text;
        noteImage.sprite = image;
    }
}
