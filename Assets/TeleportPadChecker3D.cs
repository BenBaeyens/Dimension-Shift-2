using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPadChecker3D : MonoBehaviour
{

    TeleportPad parentPad;

    #region Methods

    void Start()
    {
        // Get the teleport script from the parent 
        parentPad = transform.GetComponentInParent<TeleportPad>();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            parentPad.Teleport();
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("Player")){
            parentPad.Resume();
        }
    }

    #endregion
}
