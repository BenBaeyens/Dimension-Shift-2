using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPad : MonoBehaviour
{

    public GameObject TeleportToOtherPad;
        TeleportPad otherPad;
    public Vector3 offset = new Vector3(0, .6f, 0);

    public bool canTeleport = true;

    GameObject player;

    #region Methods

    void Start()
    {
        // Attempt to get the teleport pad from the selected gameobject.
        TeleportToOtherPad.TryGetComponent<TeleportPad>(out otherPad);
        player = GameObject.Find("Player");
    }

    public void Teleport(){
        // teleport player and halt the other pad
        Debug.Log("TEST");
        if(canTeleport){
            otherPad.Halt();
            player.transform.GetChild(0).position = TeleportToOtherPad.transform.position + offset;
        }
    }

    public void Halt(){
        // Stop teleportation if you're being teleported to the pad, so you don't have an infinite loop.
        canTeleport = false;
    }

    public void Resume(){
        // When they player exits the pad, allow for teleportation
        canTeleport = true;
    }



    #endregion
}
