using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector3 initial_position;
    [SerializeField] private float speed_force = 0.01f;
    private float speed = 1;
    [SerializeField] private KeyCode moveUp = KeyCode.W; 
    [SerializeField] private KeyCode moveDown = KeyCode.S; 
    private Rigidbody2D rigidbody2D;

    void Awake()
    {
        initial_position = transform.position;
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        move();
    }

    void move()
    {
        if (Input.GetKey(moveUp))
        {
            rigidbody2D.AddForce(Vector2.up * (speed_force * speed), ForceMode2D.Impulse);
        }
        
        if (Input.GetKey(moveDown))
        {
            rigidbody2D.AddForce(Vector2.down * (speed_force * speed), ForceMode2D.Impulse);
        }
    }

    public void set_speed(float new_speed)
    {
        if (new_speed < 10)
        {
            speed = new_speed;
        }
    }

    public void ResetPosition()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        rigidbody2D.velocity = Vector2.zero;
        transform.position = initial_position;
    }
}
