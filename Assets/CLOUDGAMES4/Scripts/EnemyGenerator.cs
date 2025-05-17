using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [Header("Enemies")]
    [SerializeField] private GameObject basicEnemy;
    [SerializeField] private GameObject kamikazeEnemy;
    [SerializeField] private GameObject boss;
    [Header("Enemy Generation Intervals")]
    [SerializeField] private float basicEnemySpawnRate;
    [SerializeField] private float kamikazeEnemySpawnRate;
    [SerializeField] private float bossSpawnRate;
    [SerializeField] private GameObject player;

    private GameObject currentBoss = null;
    private float bossTimer = 0f;
    void Start()
    {
        basicEnemy.GetComponent<BasicEnemy>().playerTransform = player.transform;
        kamikazeEnemy.GetComponent<KamikazeEnemy>().playerTransform = player.transform;

        StartCoroutine(SpawnBasicEnemy());
        StartCoroutine(SpawnKamikazeEnemy());
        StartCoroutine(SpawnBoss());
    }

    IEnumerator SpawnBasicEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(basicEnemySpawnRate);
            if (currentBoss == null)
            {
                Vector2 spawnPosition = new Vector2(9.8f, Random.Range(-4.11f, 4.11f));
                Instantiate(basicEnemy, spawnPosition, Quaternion.identity);
            }
        }
    }

    IEnumerator SpawnKamikazeEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(kamikazeEnemySpawnRate);
            if (currentBoss == null)
            {
                Vector2 spawnPosition = new Vector2(9.8f, Random.Range(-4.11f, 4.11f));
                Instantiate(kamikazeEnemy, spawnPosition, Quaternion.identity);
            }
        }
    }
    IEnumerator SpawnBoss()
    {
        while (true)
        {
            if (currentBoss == null)
            {
                bossTimer += Time.deltaTime;
                if (bossTimer >= bossSpawnRate)
                {
                    Vector2 spawnPosition = new Vector2(6.784312f, Random.Range(-4.11f, 4.11f));
                    currentBoss = Instantiate(boss, spawnPosition, Quaternion.identity);
                    bossTimer = 0f;
                    StartCoroutine(CheckBossHealth());
                }
            }
            yield return null;
        }
    }

    IEnumerator CheckBossHealth()
    {
        while (currentBoss != null)
        {
            if (currentBoss.GetComponent<BossController>().life <= 0)
            {
                currentBoss = null;
            }
            yield return new WaitForSeconds(1);
        }
    }
}
