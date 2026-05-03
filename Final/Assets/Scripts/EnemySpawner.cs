using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;

    public Transform[] waypoints; // 👈 ADD THIS

    private int spawnIndex = 0;

    public void SpawnOneEnemy()
    {
        Transform spawn = spawnPoints[spawnIndex % spawnPoints.Length];

        GameObject enemy = Instantiate(enemyPrefab, spawn.position, Quaternion.identity);

        // 👇 SEND WAYPOINTS TO ENEMY
        EnemyAI ai = enemy.GetComponent<EnemyAI>();
        ai.SetWaypoints(waypoints);

        spawnIndex++;
    }
}