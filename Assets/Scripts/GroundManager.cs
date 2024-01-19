using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 300);
    }
}
