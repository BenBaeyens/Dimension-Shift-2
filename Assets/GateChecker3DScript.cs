using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateChecker3DScript : MonoBehaviour
{

    void OnTriggerEnter(Collider other) // Check if the player interacts with the 3D Object
    {
        if(other.CompareTag("Player"))
            transform.parent.parent.GetComponent<GateControllerScript>().EnteredHitbox();
    }

    private void OnTriggerExit(Collider other) { // Check if the player interacts with the 3D Object
        if(other.CompareTag("Player"))
            transform.parent.parent.GetComponent<GateControllerScript>().LeftHitbox();  
    }
}
