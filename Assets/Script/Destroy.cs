using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    void Start() 
    {

    }

    private void OnTriggerEnter(Collider other) {
        
        if(other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}