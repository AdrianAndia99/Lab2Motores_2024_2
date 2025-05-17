using System.Collections;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; // Arreglo de prefabs de obstáculos
    public float[] spawnTimes; // Arreglo de tiempos de generación
    public bool[] spawnPointsToggle; // Arreglo de booleanos para elegir el punto de generación
    public Transform spawnPoint1; // Primer punto de generación
    public Transform spawnPoint2; // Segundo punto de generación

    void Start()
    {
        if (obstaclePrefabs.Length != spawnTimes.Length || obstaclePrefabs.Length != spawnPointsToggle.Length)
        {
            Debug.LogError("Los arreglos en el inspector deben de tener la misma longitud");
            return;
        }

        for (int i = 0; i < obstaclePrefabs.Length; ++i)
        {
            StartCoroutine(SpawnObstacle(obstaclePrefabs[i], spawnTimes[i], spawnPointsToggle[i]));
        }
    }

    IEnumerator SpawnObstacle(GameObject obj, float delay, bool positionSelect)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            Transform spawnPoint = positionSelect ? spawnPoint1 : spawnPoint2;
            GameObject obstacle = Instantiate(obj, spawnPoint.position, Quaternion.identity);
            Obstacle obstacleScript = obstacle.GetComponent<Obstacle>();
            if (obstacleScript != null)
            {
                obstacleScript.moveUp = positionSelect;
            }
        }
    }
}
