using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimentionChecker : MonoBehaviour
{

    DimentionShift dimentionShift;

    #region Methods

    private void Start() {
        dimentionShift = GameObject.Find("Dimention Swapper").GetComponent<DimentionShift>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        dimentionShift.DimentionPosition(other.gameObject);
        if(other.gameObject.CompareTag("MovingPlatform") && dimentionShift.currently3D){
            transform.parent.SetParent(other.transform.parent.parent);
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.CompareTag("MovingPlatform")){
            transform.parent.SetParent(null);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("MovingPlatform")){
            transform.parent.SetParent(other.transform.parent.parent);
        }
    }

    void OnCollisionExit(Collision other)
    {
        if(other.gameObject.CompareTag("MovingPlatform")){
            transform.parent.SetParent(null);
        }
    }
    #endregion
}
