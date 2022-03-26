using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    public Subtitle subtitle;

    // Start is called before the first frame update
    void Start()
    {
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            if (subtitle != null)
            {
                FindObjectOfType<Reacting>().PlayClip(subtitle.clip);
                FindObjectOfType<HUD>().ShowSubtitle(subtitle);
                Destroy(gameObject);
            }      
        }     
    }
}
