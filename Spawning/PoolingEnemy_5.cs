using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PoolingEnemy_5 : MonoBehaviour
{
    
    private const int POOL_SIZE_E1 = 7;

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] protected Transform spamPoint;
    [SerializeField] private float spamTime;
    [SerializeField] public bool isStart;

    private Queue<GameObject> enemyPool;

    [Header("Transform")]
    [SerializeField] private float _BoundsMinX;
    [SerializeField] private float _BoundsMaxX;
    [SerializeField] private float _BoundsMinY;
    [SerializeField] private float _BoundsMaxY;


    void Start()
    {
        isStart = false;

        enemyPool = new Queue<GameObject>();

        for (int i = 0; i < POOL_SIZE_E1; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, Vector3.zero, Quaternion.identity);
            enemy.SetActive(false);
            enemyPool.Enqueue(enemy);

        }
        StartCoroutine(AsterWave());

    }

    private GameObject GetGemFromPool()
    {
        if (enemyPool.Count > 0)
        {
            GameObject enemy = enemyPool.Dequeue();
            enemy.SetActive(true);
            return enemy;
        }


        return null;
    }

    private void ReturnGemToPool(GameObject enemy)
    {
        enemy.SetActive(false);
        enemyPool.Enqueue(enemy);
    }


    private void SpawmObject()
    {
        if (isStart)
        {
            GameObject enemy = GetGemFromPool();

            Vector2 newSpawn = new Vector2(Random.Range(_BoundsMinX, _BoundsMaxX), Random.Range(_BoundsMinY, _BoundsMaxY));


            if (enemy != null)
            {
                enemy.transform.position = newSpawn;
                enemy.SetActive(true);

                StartCoroutine(DisableGemAfterDelay(enemy, 11.5f));
            }
        }

    }



    private IEnumerator DisableGemAfterDelay(GameObject enemy, float delay)
    {

        yield return new WaitForSeconds(delay);

        ReturnGemToPool(enemy);

    }
    private IEnumerator AsterWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(spamTime);
            SpawmObject();
            

        }

    }
}
