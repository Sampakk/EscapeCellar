using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndKeyScript : MonoBehaviour
{
   
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Door")
        {
            Destroy(collision.gameObject);
            //WinGame
        }
    }

   
}
