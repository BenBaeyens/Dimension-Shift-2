using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelScript : MonoBehaviour
{

    public float rotationSpeed = 1f;

    #region Methods

    private void FixedUpdate() {
        float speed = 1 * rotationSpeed;
        transform.rotation *= Quaternion.Euler(speed, speed, speed);
    }

    #endregion
}
