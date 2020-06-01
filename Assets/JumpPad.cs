using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    GameObject player;

    public float jumpForce = 350f;

    #region Methods

    void Start()
    {
        player = GameObject.Find("Player");
    }
    
    public void Jump(){
        Debug.Log("JUMP");
        Vector3 vel = player.transform.GetChild(0).GetComponent<Rigidbody>().velocity;
        player.transform.GetChild(0).GetComponent<Rigidbody>().velocity = new Vector3(vel.x, 0, vel.z);
        player.transform.GetChild(0).GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce);
    }

    #endregion
}
