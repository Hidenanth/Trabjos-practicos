using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab; 
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private Vector2 spawnArea = new Vector2(-5, 5); 
    private GameManager game_manager;

    private List<GameObject> active_obstacles = new List<GameObject>(); // Lista de obstáculos activos

    private void Awake()
    {
        game_manager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        StartCoroutine(SpawnObstacles());
    }

    private IEnumerator SpawnObstacles()
    {
        while (true)
        {
            if (game_manager.is_game_active) // Si el juego está activo
            {
                SpawnObstacle();
                yield return new WaitForSeconds(spawnInterval);
            }
            else
            {
                DestroyAllObstacles(); // Destruir todos los obstáculos si el juego no está activo
                yield return null; // Espera un frame
            }
        }
    }

    private void SpawnObstacle()
    {
        Vector2 randomPosition = new Vector2(
            Random.Range(-spawnArea.x / 2, spawnArea.x / 2),
            Random.Range(-spawnArea.y / 2, spawnArea.y / 2)
        );

        GameObject obstacle = Instantiate(obstaclePrefab, randomPosition, Quaternion.identity);
        active_obstacles.Add(obstacle); // Añadir a la lista de obstáculos activos
        StartCoroutine(DestroyObstacleAfterTime(obstacle));
    }

    private IEnumerator DestroyObstacleAfterTime(GameObject obstacle)
    {
        float lifetime = Random.Range(3f, 7f);
        yield return new WaitForSeconds(lifetime);
        Destroy(obstacle);
        active_obstacles.Remove(obstacle); // Remover de la lista al destruir
    }

    private void DestroyAllObstacles()
    {
        foreach (GameObject obstacle in active_obstacles)
        {
            Destroy(obstacle);
        }
        active_obstacles.Clear();
    }
}
