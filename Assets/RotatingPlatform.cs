using System.Collections;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    public float rotationSpeedInSeconds = 1f; // The speed at which the platform rotates

    [Tooltip("The time the platform pauses before moving on to it's next action, in seconds.")]
    public float pauseTime = 2f; // The time the platform pauses before moving on to it's next action
    public float rotationAngle = 180f; // How many degrees the platform should rotate in the given direction

    [Tooltip("Bounce back after doing the rotation to one side.")]
    public bool doBounceAction = true; // Bounce back after doing the rotation to one side.
    public bool reverseDirection = false; // Reverse the direction the platform spins in.

    public enum Direction {x, y, z}; // Which direction the platform rotates in
    public Direction rotationDirection;

    bool canRotate = true;
    int currentRotationDirection = 1;
    float degreesLeft;
    float degreesThisFrame;

    void Start()
    {
        degreesLeft = rotationAngle;
        if(reverseDirection)
            currentRotationDirection *= -1;
    }

    void Update()
    {
        if(canRotate){
            degreesThisFrame = (rotationAngle * Time.deltaTime) / rotationSpeedInSeconds;
            if(degreesThisFrame > degreesLeft){
                degreesThisFrame = degreesLeft;
                StartCoroutine("PlatformWait");
            }
            switch(rotationDirection){ // Rotate in the given angle
                case Direction.x:
                    transform.Rotate(degreesThisFrame * currentRotationDirection, 0f, 0f);
                    break;
                case Direction.y:
                    Debug.Log("ROTATING");
                    PlayerController pc = GetComponentInChildren<PlayerController>();
                    if(pc != null){
                        Debug.Log("FOUND PLAYERCONTROLLER");
                        pc.transform.Rotate(0f, degreesThisFrame * -currentRotationDirection, 0f);
                    }
                    transform.Rotate(0f, degreesThisFrame * currentRotationDirection, 0f);
                    break;
                case Direction.z:
                    transform.Rotate(0f, 0f, degreesThisFrame * currentRotationDirection);
                    break;
            }
            degreesLeft -= degreesThisFrame;
        }
    }

    IEnumerator PlatformWait(){ // Wait and reset, if necessary, reverse direction
        canRotate = false;
        yield return new WaitForSeconds(pauseTime);
        if(doBounceAction)
            currentRotationDirection *= -1;
        degreesLeft = rotationAngle;
        canRotate = true;
    }
}
