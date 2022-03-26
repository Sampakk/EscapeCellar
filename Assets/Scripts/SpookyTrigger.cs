using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpookyTrigger : MonoBehaviour
{
    public Transform spawnPosition;
    public GameObject spookPrefab;
    public float lifetime;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            if (spookPrefab != null && spawnPosition != null)
            {
                GameObject spook = Instantiate(spookPrefab, spawnPosition.position, Quaternion.LookRotation(spawnPosition.forward));
                Destroy(spook, lifetime);
                Destroy(gameObject);
            }
        }
    }
}
