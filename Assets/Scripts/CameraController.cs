using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    DimentionShift dimentionShift;

    [Tooltip("The object the camera will follow.")]
    [SerializeField] GameObject followObject;
    [Tooltip("Check this box if the \nfollow object is 3D.")]
    [SerializeField] bool objectIs3D;
    [Tooltip("Offset from the player to the camera")]
    [SerializeField] Vector3 offset;

    GameObject followObject3D;
    GameObject followObject2D;

    #region Methods

    private void Start() {
        dimentionShift = GameObject.Find("Dimention Swapper").GetComponent<DimentionShift>();

        if(objectIs3D){
            followObject3D = followObject.transform.GetChild(0).gameObject;
            followObject2D = followObject.transform.GetChild(1).gameObject;
        }
    }

    private void FixedUpdate() {
        if(dimentionShift.currently3D)
            transform.position = Vector3.Lerp(transform.position, followObject3D.transform.position - offset, 0.1f);
        else
            transform.position = Vector3.Lerp(transform.position, followObject2D.transform.position - offset, 0.1f);
    
    }

    #endregion
}
