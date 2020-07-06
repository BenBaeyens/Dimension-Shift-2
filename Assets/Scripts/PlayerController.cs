using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    GameObject player3D;
    GameObject player2D;

    float distToGround3D;
    float distToGround2D;

    [SerializeField] float speed = 1f; // Default movement speed
    [SerializeField] float jumpForce = 50f; // Default jump force

    DimentionShift dimentionShift;

    #region Methods

    private void Start() {
        dimentionShift = GameObject.Find("Dimention Swapper").GetComponent<DimentionShift>();

        player3D = transform.GetChild(0).gameObject;
        player2D = transform.GetChild(1).gameObject;
        
        distToGround3D = player3D.GetComponent<Collider>().bounds.extents.y; // Get the distance from the player to the ground
        distToGround2D = player2D.GetComponent<Collider2D>().bounds.extents.y; // The same for 2D space
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded()){
            player2D.GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpForce);
            player3D.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce);
        }
    
    }

    private void FixedUpdate() {
        if(dimentionShift.currently3D){
            transform.position += (new Vector3(Input.GetAxis("Horizontal") * speed / 5, 0f, Input.GetAxis("Vertical") * speed / 5)); // move the player
            player2D.transform.position = player3D.transform.position;
        }else
            transform.position += (new Vector3(Input.GetAxis("Horizontal") * speed / 5, 0f, 0f));
    }

    bool isGrounded(){ // Check if the player is on the ground
        if(dimentionShift.currently3D)
            return Physics.Raycast(player3D.transform.position, -Vector3.up, distToGround3D + 0.1f); 
        else
            return Physics2D.Raycast(player2D.transform.position, -Vector2.up, distToGround2D + 0.1f);   
    }

    #endregion
}
