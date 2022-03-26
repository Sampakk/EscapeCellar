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

    public GameObject steamRight;
    public GameObject steamLeft;
    public GameObject steamForward;

    void Start()
    {
        m_Collider = GetComponent<Collider>();
        m_Rigidbody = GetComponent<Rigidbody>();

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            //m_Collider.enabled = false;
            transform.position = collision.transform.position;
            transform.rotation = collision.transform.rotation;
            m_Rigidbody.isKinematic = true;

            StartCoroutine("RotateMinuteHand");

            if(collision.gameObject.name == "CogPlacementRight")
            {
                steamRight.SetActive(false);
                steamLeft.SetActive(true);
                steamForward.SetActive(true);
            }
            else if(collision.gameObject.name == "CogPlacementLeft")
            {
                steamRight.SetActive(true);
                steamLeft.SetActive(false);
                steamForward.SetActive(true);
            }
            else if (collision.gameObject.name == "CogPlacementForward")
            {
                steamRight.SetActive(true);
                steamLeft.SetActive(true);
                steamForward.SetActive(false);
            }
        }
    }


    void Update()
    {

    }

    private IEnumerator RotateMinuteHand()
    {
        for (int i = 0; i <= 9; i++)
        {
            transform.Rotate(0f, 0f, 9f);
            yield return new WaitForSeconds(0.04f);

        }
    }
}
