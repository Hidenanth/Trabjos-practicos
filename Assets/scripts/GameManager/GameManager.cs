using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Ball ball;
    [SerializeField] private float launch_force = 5f;
    [SerializeField] private ui_main_menu ui;
    [SerializeField] private Movement player_1;
    [SerializeField] private Movement player_2;

    public int points_player_1 = 0;
    public int points_player_2 = 0;
    public bool is_game_active = false; // Cambiado a false inicialmente

    private void Awake()
    {
        player_1 = FindObjectOfType<Movement>();
        player_2 = FindObjectOfType<Movement>();
        ui = FindObjectOfType<ui_main_menu>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !is_game_active) // Cambiado a !is_game_active
        {
            LaunchBall();
        }
    }

    private void LaunchBall()
    {
        ResetBall();

        Vector2 launch_direction = GetRandomLaunchDirection();
        ball.GetComponent<Rigidbody2D>().AddForce(launch_direction * launch_force, ForceMode2D.Impulse);

        ui.inicio_game();
        is_game_active = true; // Cambiar el estado del juego a activo
    }

    private Vector2 GetRandomLaunchDirection()
    {
        float direction = Random.value < 0.5f ? -1f : 1f;
        return new Vector2(direction, Random.Range(-0.5f, 0.5f)).normalized;
    }

    public void AddPointsToPlayer1(int points)
    {
        points_player_1 += points;
        ResetBallPosition();
        ui.reset_game();
        is_game_active = false;
        player_1.ResetPosition();
        player_2.ResetPosition();
    }

    public void AddPointsToPlayer2(int points)
    {
        points_player_2 += points;
        ResetBallPosition();
        ui.reset_game();
        is_game_active = false;
        player_1.ResetPosition();
        player_2.ResetPosition();
    }

    private void ResetBallPosition()
    {
        ball.transform.position = Vector2.zero; // Mover la pelota al centro
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero; // Detener la pelota
    }

    private void ResetBall()
    {
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero; // Detener la pelota
    }
}
