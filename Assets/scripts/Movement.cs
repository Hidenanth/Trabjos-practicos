using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 0.03f;
    [SerializeField] private KeyCode moveUp = KeyCode.W; 
    [SerializeField] private KeyCode moveDown = KeyCode.S; 
    [SerializeField] private KeyCode moveLeft= KeyCode.A;
    [SerializeField] private KeyCode moveRight = KeyCode.D;
    [SerializeField] private KeyCode rotateRight = KeyCode.E;
    [SerializeField] private KeyCode rotateLeft = KeyCode.Q;
    [SerializeField] private KeyCode randomColor = KeyCode.F;
    [SerializeField] private float angle = 10f;
    private SpriteRenderer spriteRenderer;
    private float rotation = 0;

    void Awake()
    {
        // Obtén el componente SpriteRenderer en el GameObject al que está adjunto este script
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Obtiene la posición actual del objeto
        Vector3 pos = transform.position;

        if (Input.GetKeyUp(randomColor))
        {
            spriteRenderer.color = new Color(Random.value, Random.value, Random.value);
        }

        // Rotar hacia la izquierda
        if (Input.GetKeyDown(rotateRight))
        {
            rotation -= angle;

            transform.Rotate(0, 0, rotation);
        }

        // Rotar hacia la derecha
        if (Input.GetKeyDown(rotateLeft))
        {
            rotation += angle;

            transform.Rotate(0, 0, rotation);
        }

        // Movimiento hacia arriba
        if (Input.GetKey(moveUp))
        {
            pos.y += speed;
        }

        // Movimiento hacia la izquierda
        if (Input.GetKey(moveLeft))
        {
            pos.x -= speed;
        }

        // Movimiento hacia abajo
        if (Input.GetKey(moveDown))
        {
            pos.y -= speed;
        }

        // Movimiento hacia la derecha
        if (Input.GetKey(moveRight))
        {
            pos.x += speed;
        }

        // Actualiza la posición del objeto
        transform.position = pos;

        
    }

    public void set_speed(float new_speed)
    {
        if (new_speed < 1.5f)
        {
            speed = new_speed;
        }
            
    }


}

