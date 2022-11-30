using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner2 : MonoBehaviour
{
    public float respawnTime = 1.0f;
    public GameObject[] cubePrefab;
    private Vector2 scBount;
    private int randEnemy;
    public PlayerCode plc;



    private void Awake()
    {

    }

    void Start()
    {
        scBount = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height * 13 / 20, Camera.main.transform.position.z));
        StartCoroutine(AsterWave());
    }

    void Update()
    {



    }

    private void spawnEnemy()
    {
        if (plc.WeScore >= 20)
        {

            randEnemy = Random.Range(0, cubePrefab.Length);
            GameObject a = Instantiate(cubePrefab[randEnemy]) as GameObject;
            a.transform.position = new Vector2(scBount.x * 2, Random.Range(scBount.y, -scBount.y));

        }
    }
    IEnumerator AsterWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }

    }
}
