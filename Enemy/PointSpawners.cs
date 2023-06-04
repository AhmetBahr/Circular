using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpawners : MonoBehaviour
{
    [SerializeField] private GameObject[] Points_1;
    [SerializeField] private GameObject[] Points_2;


    private int randPoint;
    private bool isStart = false;

    private float respawnTime = 4.5f;

    public float _BoundsMinX, _BoundsMaxX;
    public float _BoundsMinY, _BoundsMaxY;

    [SerializeField] private int currentScore;

    ManuScript mncript;

    void Start()
    {
        mncript = GameObject.Find("Manager").GetComponent<ManuScript>();
        currentScore = mncript.score;
    }


    void Update()
    {
        currentScore = mncript.score;

    }


    void SpawnObject_1()
    {
        Vector2 newSpawn = new Vector2(Random.Range(_BoundsMinX, _BoundsMaxX), Random.Range(_BoundsMinY, _BoundsMaxY));
        Instantiate(Points_1[randPoint], newSpawn, Quaternion.identity);


    }
    void SpawnObject_2()
    {
        Vector2 newSpawn = new Vector2(Random.Range(_BoundsMinX, _BoundsMaxX), Random.Range(_BoundsMinY, _BoundsMaxY));
        Instantiate(Points_2[randPoint], newSpawn, Quaternion.identity);


    }
    IEnumerator AsterWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);

            if(currentScore <= 40)
            {
                SpawnObject_1();
            }
            if(currentScore > 40) 
            {
                SpawnObject_2();
            }

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
