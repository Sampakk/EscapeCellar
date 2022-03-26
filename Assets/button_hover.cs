using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class button_hover : MonoBehaviour, IPointerEnterHandler
{
    public AudioSource audiosource;
    public AudioClip menuclick;
    public float audiovolume = 1f;
    public void OnPointerEnter(PointerEventData eventData)
    {
        audiosource.PlayOneShot(menuclick, audiovolume);
    }
}
