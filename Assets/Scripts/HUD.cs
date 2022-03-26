using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
    Player player;
    Interactables interactables;

    [Header("HUD")]
    public TextMeshProUGUI noteText;
    public Image noteImage;
    public TextMeshProUGUI interactText;

    [Header("Subtitles")]
    public TextMeshProUGUI subtitleText;
    float subtitleDuration = 5f;
    float subtitleShowTime;

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
        HandleSubtitles();
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

    public void ShowSubtitle(Subtitle subtitle)
    {
        subtitleText.text = subtitle.text;
        subtitleShowTime = Time.time;
        subtitleDuration = subtitle.clip.length * 1.2f;
    }

    void HandleSubtitles()
    {
        if (Time.time >= subtitleShowTime + subtitleDuration)
        {
            subtitleText.text = "";
        }
    }
}
