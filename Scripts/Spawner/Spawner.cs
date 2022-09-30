using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float respawnTime = 1.0f;
    public GameObject[] cubePrefab;
    private Vector2 scBount;
    private int randEnemy;
    private int basladý = 0;
    private bool b1 = false;



    void Start()
    {
        scBount = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height * 13 /20, Camera.main.transform.position.z));
        StartCoroutine(AsterWave());
    }

    void Update()
    {
        if (b1)
        {
            basladý = 1;

        }

    }

    private void spawnEnemy()
    {

        if (basladý == 1)
        {
            randEnemy = Random.Range(0, cubePrefab.Length);
            GameObject a = Instantiate(cubePrefab[randEnemy]) as GameObject;
            a.transform.position = new Vector2(scBount.x * -2, Random.Range(scBount.y, -scBount.y));

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


    public void B1()
    {
        b1 = true;
    }

}
