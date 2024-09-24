using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDefault : MonoBehaviour
{ 
    [SerializeField] private KeyCode rotate_default = KeyCode.F; 

    void Update()
    {
        if (Input.GetKeyDown(rotate_default))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0); // Establece la rotación a (0, 0, 0)
        }
    }
}
