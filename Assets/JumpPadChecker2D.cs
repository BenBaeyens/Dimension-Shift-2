using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPadChecker2D : MonoBehaviour
{
    JumpPad parentPad;

    #region Methods

    void Start()
    {
        // Get the teleport script from the parent 
        parentPad = transform.GetComponentInParent<JumpPad>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            parentPad.Jump();
        }
    }

    #endregion
}