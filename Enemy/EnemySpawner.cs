using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemySpawner : MonoBehaviour
{
    [Header("Object")]
    [SerializeField] private GameObject[] EnemyObject_1;
    [SerializeField] private GameObject[] EnemyObject_2;
    [SerializeField] private GameObject[] EnemyObject_3;
    [SerializeField] private GameObject[] EnemyObject_4;
    [SerializeField] private GameObject[] EnemyObject_5;

    [SerializeField] private float respawnTime = 3f;

    private bool isStart = false;

    [Header("Transform")]
    [SerializeField] private float _BoundsMinX;
    [SerializeField] private float _BoundsMaxX;
    [SerializeField] private float _BoundsMinY;
    [SerializeField] private float _BoundsMaxY;


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
        Instantiate(EnemyObject_1[Random.RandomRange(0,EnemyObject_1.Length)], newSpawn, Quaternion.identity);


    }

    void SpawnObject_2()
    {

        Vector2 newSpawn = new Vector2(Random.Range(_BoundsMinX, _BoundsMaxX), Random.Range(_BoundsMinY, _BoundsMaxY));
        Instantiate(EnemyObject_2[Random.RandomRange(0, EnemyObject_2.Length)], newSpawn, Quaternion.identity);


    }

    void SpawnObject_3()
    {
        Vector2 newSpawn = new Vector2(Random.Range(_BoundsMinX, _BoundsMaxX), Random.Range(_BoundsMinY, _BoundsMaxY));
        Instantiate(EnemyObject_3[0], newSpawn, Quaternion.identity);


    }
    void SpawnObject_4()
    {
        Vector2 newSpawn = new Vector2(Random.Range(_BoundsMinX, _BoundsMaxX), Random.Range(_BoundsMinY, _BoundsMaxY));
        Instantiate(EnemyObject_4[0], newSpawn, Quaternion.identity);


    }
    void SpawnObject_5()
    {
        Vector2 newSpawn = new Vector2(Random.Range(_BoundsMinX, _BoundsMaxX), Random.Range(_BoundsMinY, _BoundsMaxY));
        Instantiate(EnemyObject_5[0], newSpawn, Quaternion.identity);


    }
    IEnumerator AsterWave()
    {
        


        while (true)
        {
            yield return new WaitForSeconds(respawnTime);

            if (currentScore <= 5)
            {
                SpawnObject_1();
            }
            if (currentScore > 5 && currentScore <=15)
            {
                SpawnObject_2();
            }
            if (currentScore > 15 && currentScore <= 35)
            {
                SpawnObject_3();
            }
            if (currentScore > 35 && currentScore <= 65)
            {
                SpawnObject_4();
            }
            if (currentScore > 65 )
            {
                SpawnObject_5();
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
