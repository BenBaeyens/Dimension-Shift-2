using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLevel : MonoBehaviour
{



    #region Methods

    void Start()
    {
        DontDestroyOnLoad(this);
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)){ // Exit the game when the escape key is pressed
            Application.Quit();
            Debug.LogWarning("WARNING: QUITTING APPLICATION");
        }
    }

    #endregion
}
