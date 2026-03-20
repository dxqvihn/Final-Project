using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies; // mang chua enemy trong game
    [SerializeField] private Transform[] spawnPoints; // diem ngau nhien se sinh ra enemy
    [SerializeField] private float timeBetweenSpawns = 2.5f; // khoang thoi gian giua hai lan sinh enemy

    void Start()
    {
        StartCoroutine(SpawnEnemyCoroutine()); // sinh ra enemy lien tuc
    }

    private IEnumerator SpawnEnemyCoroutine() // lam nhiem vu spawn enemy
    {
        while (true) // de sinh enemy lien tuc
        {
            yield return new WaitForSeconds(timeBetweenSpawns); // tro thoi gian sinh enemy
            GameObject enemy = enemies[Random.Range(0, enemies.Length)]; // chon ngau nhien cac con trong enemy de sinh
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)]; // chon ngau nhien vi tri de sinh
            Instantiate(enemy, spawnPoint.position,Quaternion.identity); // sinh ra enemy da dc chon
        }
    }

    
}
