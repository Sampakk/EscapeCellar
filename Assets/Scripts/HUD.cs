using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
    public Canvas interactionRoot;
    public Image backgroundImage;
    public TextMeshProUGUI noteText;
    public Image noteImage;

    // Start is called before the first frame update
    void Start()
    {
        interactionRoot.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableNote(string text)
    {
        interactionRoot.enabled = true;
        noteText.text = text;
    }
    public void EnableNotePicture(string text, Sprite image)
    {
        interactionRoot.enabled = true;
        noteText.text = text;
        noteImage.sprite = image;
    }
}
