using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingPoint : MonoBehaviour
{
    private const int POOL_SIZE = 6;

    [SerializeField] private GameObject gemPrefeb;
    [SerializeField] protected Transform spamPoint;
    [SerializeField] private float spamTime;
    [SerializeField] private bool isStart;

    private Queue<GameObject> gemPool;

    [Header("Transform")]
    [SerializeField] private float _BoundsMinX;
    [SerializeField] private float _BoundsMaxX;
    [SerializeField] private float _BoundsMinY;
    [SerializeField] private float _BoundsMaxY;


    void Start()
    {
        gemPool = new Queue<GameObject>();

        for(int i =0; i< POOL_SIZE; i++)
        {
            GameObject gem = Instantiate(gemPrefeb, Vector3.zero, Quaternion.identity);
            gem.SetActive(false);
            gemPool.Enqueue(gem);
        
        }

    }
    
    private GameObject GetGemFromPool()
    {
        if(gemPool.Count > 0)
        {
            GameObject gem = gemPool.Dequeue();
            gem.SetActive(true);
            return gem;
        }


        return null;
    }

    private void ReturnGemToPool(GameObject gem)
    {
        gem.SetActive(false);
        gemPool.Enqueue(gem);
    }


    private void SpawmObject()
    {
        GameObject gem = GetGemFromPool();

        Vector2 newSpawn = new Vector2(Random.Range(_BoundsMinX, _BoundsMaxX), Random.Range(_BoundsMinY, _BoundsMaxY));


        if (gem != null)
        {
            gem.transform.position = newSpawn;
            gem.SetActive(true);

            StartCoroutine(DisableGemAfterDelay(gem, 8f));
        }
    }

    public void StartFunk()
    {
        isStart = true;
        if (isStart)
        {
            StartCoroutine(AsterWave());
        }
    }


    private IEnumerator DisableGemAfterDelay(GameObject gem, float delay)
    {

        yield return new WaitForSeconds(delay);

        ReturnGemToPool(gem);

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
