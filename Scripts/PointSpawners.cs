using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpawners : MonoBehaviour
{
    [SerializeField] private GameObject[] Points;

    private int randPoint;
    private bool isStart = false;

    private float respawnTime = 4f;

    public float _BoundsMinX, _BoundsMaxX;
    public float _BoundsMinY, _BoundsMaxY;

    void Start()
    {

    }


    void Update()
    {
  
    }


    void SpawnObject()
    {
        Vector2 newSpawn = new Vector2(Random.Range(_BoundsMinX, _BoundsMaxX), Random.Range(_BoundsMinY, _BoundsMaxY));
        Instantiate(Points[randPoint], newSpawn, Quaternion.identity);


    }
    IEnumerator AsterWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnObject();
        }

    }

    public void isStartFunk()
    {
        isStart = true;
        if (isStart)
        {
            StartCoroutine(AsterWave());
        }
    }
    public void isStartStopFunk()
    {
        isStart = false;
    }

}
