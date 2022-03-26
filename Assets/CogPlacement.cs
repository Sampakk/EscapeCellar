using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogPlacement : MonoBehaviour
{
    Collider m_Collider;
    Rigidbody m_Rigidbody;

    static bool rotate = false;
    static bool rightOrder1 = false;
    static bool rightOrder2 = false;
    static bool rightOrder3 = false;
    static bool Staticoccupied = false;
    bool occupied = false;
    

    void Start()
    {
        m_Collider = GetComponent<Collider>();
        m_Rigidbody = GetComponent<Rigidbody>();

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            transform.position = collision.transform.position;
            occupied = true;
            collision.gameObject.layer = 3;

        }

        if (gameObject.tag == "rightCog")
        {
            if (collision.gameObject.tag == "rightCog")
            {

                rightOrder1 = true;

                Debug.Log("Left Cog is " + rightOrder1);
            }
            
            else
            {
                rightOrder1 = false;
                Debug.Log("Left Cog is" + rightOrder1);
            }

        }

        if (gameObject.tag == "middleCog")
        {
            if (collision.gameObject.tag == "middleCog")
            {

                rightOrder2 = true;
                Debug.Log("Middle Cog is " + rightOrder2);
            }

            else
            {
                rightOrder2 = false;
                Debug.Log("Middle Cog is " + rightOrder2);
            }

        }

        if (gameObject.tag == "leftCog")
        {
            if (collision.gameObject.tag == "leftCog")
            {

                rightOrder3 = true;
                Debug.Log("Right Cog is " + rightOrder3);
            }

            else
            {
                rightOrder3 = false;
                Debug.Log("Right Cog is " + rightOrder3);
            }

        }

        if (rightOrder1 && rightOrder2 && rightOrder3)
        {
            Debug.Log("Puzzle Won");
            m_Collider.enabled = false;
            m_Rigidbody.isKinematic = true;
            rotate = true;
            


        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 3) collision.gameObject.layer = 8;
    }
    void Update()
    {
        if(rotate) transform.Rotate(0, 0, 100 * Time.deltaTime);
    }


}
