using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogPlacement : MonoBehaviour
{
    Collider m_Collider;
    Rigidbody m_Rigidbody;
    static int CogCount = 0;
    static bool rotate = false;
    int CogAmount = 3;
    
    

    void Start()
    {
        m_Collider = GetComponent<Collider>();
        m_Rigidbody = GetComponent<Rigidbody>();

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            m_Collider.enabled = false;
            transform.position = collision.transform.position;
            transform.rotation = collision.transform.rotation;
            m_Rigidbody.isKinematic = true;
            collision.gameObject.layer = 3;
            CogCount++;

        }

        if (CogAmount == CogCount) rotate = true;
    }

  
    void Update()
    {
        if(rotate) transform.Rotate(0, 0, 100 * Time.deltaTime);
    }


}
