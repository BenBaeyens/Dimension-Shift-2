using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateScript : MonoBehaviour
{
    public bool isOpen;
    public int GateID;

    public void OpenGate(){
        if(!isOpen){ // Add the isOpen bool to prevent animations playing twice.
            // Play animtation
            transform.GetChild(0).gameObject.SetActive(false); // Disable the Gate object
            Debug.Log("GateScript: Gate with ID:" + GateID + " has been OPENED.");
            isOpen = true;
        }
    }

    public void CloseGate(){
        if(isOpen){
            // Play animation
            transform.GetChild(0).gameObject.SetActive(true);
            Debug.Log("GateScript: Gate with ID:" + GateID + " has been CLOSED.");
            isOpen = false;
        }
    }
}
