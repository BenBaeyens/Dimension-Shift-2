using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateControllerScript : MonoBehaviour
{

    public int GateID;
    public bool isPressurePlate;

    public List<GateScript> gates;

   
    void Start()
    {
        gates = new List<GateScript>();
        GateScript[] tempGates = GameObject.FindObjectsOfType<GateScript>(); // Add the available gates to a temporary array
        for (int i = 0; i < tempGates.Length; i++)
        {
            if(tempGates[i].GateID == GateID) // If the ID of the gate is the same as the defined ID, add it to the list.
                gates.Add(tempGates[i]);
        }
        Debug.Log("GateControllerScript: Found " + gates.Count + " gates with ID " + GateID + ".");
    }

    void Update()
    {
        for (int i = 0; i < gates.Count; i++)
        {
            Debug.DrawLine(transform.GetChild(0).position, gates[i].transform.position, Color.yellow);
        }
    }

    public void EnteredHitbox(){
        for (int i = 0; i < gates.Count; i++) // open the gate when the player enters.
        {
            gates[i].OpenGate();
        }
    }

    public void LeftHitbox(){
        if(isPressurePlate){ // If the object is a pressure plate, release/close the gate when the player steps off.
            for (int i = 0; i < gates.Count; i++)
            {
                gates[i].CloseGate();
            }
        }
    }
}
