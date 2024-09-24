using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float force = 10f;
    private Rigidbody2D rigidbody2D;
    private GameManager game_manager;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        game_manager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            Vector2 direction = rigidbody2D.velocity.normalized;
            rigidbody2D.AddForce(direction * force, ForceMode2D.Impulse);
        }
        
        if (other.transform.CompareTag("Limit Left"))
        {
            game_manager.AddPointsToPlayer2(1); // Incrementa los puntos del jugador 2
        }

        if (other.transform.CompareTag("Limit Right"))
        {
            game_manager.AddPointsToPlayer1(1); // Incrementa los puntos del jugador 1
        }
    }

}
