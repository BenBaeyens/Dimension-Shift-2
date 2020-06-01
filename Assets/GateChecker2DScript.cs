using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateChecker2DScript : MonoBehaviour
{
   
    void OnTriggerEnter2D(Collider2D other)// Check if the player interacts with the 3D Object
    {
        if(other.CompareTag("Player"))
            transform.parent.parent.GetComponent<GateControllerScript>().EnteredHitbox();
    
    }

    private void OnTriggerExit2D(Collider2D other) {// Check if the player interacts with the 3D Object
        if(other.CompareTag("Player"))
            transform.parent.parent.GetComponent<GateControllerScript>().LeftHitbox();
    }
}
