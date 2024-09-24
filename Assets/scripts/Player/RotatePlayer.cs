using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    [SerializeField] private KeyCode rotateRight = KeyCode.Q;
    [SerializeField] private KeyCode rotateLeft = KeyCode.E;
    [SerializeField] private float rotationSpeed = 10f;

    private Rigidbody2D rigidbody2D;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Rotate();
    }

void Rotate()
{
    // Rotar hacia la izquierda
        if (Input.GetKey(rotateRight))
        {
            rigidbody2D.AddTorque(rotationSpeed * Time.deltaTime, ForceMode2D.Impulse);
        }

        // Rotar hacia la derecha
        if (Input.GetKey(rotateLeft))
        {
            rigidbody2D.AddTorque(-rotationSpeed * Time.deltaTime, ForceMode2D.Impulse);
        }
    }
}
