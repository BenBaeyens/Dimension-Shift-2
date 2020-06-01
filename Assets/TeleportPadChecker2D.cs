using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPadChecker2D : MonoBehaviour
{

    TeleportPad parentPad;

    #region Methods

    void Start()
    {
        // Get the teleport script from the parent 
        parentPad = transform.GetComponentInParent<TeleportPad>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            parentPad.Teleport();
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")){
            parentPad.Resume();
        }
    }

    #endregion
}
