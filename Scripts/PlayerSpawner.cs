using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private int playerPoint;
    private bool isStart = false;

    private float respawnTime = 4f;

    public float _BoundsMinX, _BoundsMaxX;
    public float _BoundsMinY, _BoundsMaxY;

    void Start()
    {

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            startPlayer();

        }
    }


    void SpawnObject()
    {
        Vector2 newSpawn = new Vector2(Random.Range(_BoundsMinX, _BoundsMaxX), Random.Range(_BoundsMinY, _BoundsMaxY));
        Instantiate(player, newSpawn, Quaternion.identity);


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
    public void startPlayer()
    {
    
        SpawnObject();
    }
}
