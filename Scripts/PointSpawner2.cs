using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpawner2 : MonoBehaviour
{
    public float respawnTime = 1.0f;
    public GameObject cubePrefab;
    private Vector2 scBount;
    public PlayerCode plc;
   

    void Start()
    {
        scBount = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height * 12 / 20, Camera.main.transform.position.z));
        StartCoroutine(AsterWave());

        
    }

    void Update()
    {
        

    }

    private void spawnEnemy()
    {
        if (plc.WeScore >= 20)
        {
            GameObject a = Instantiate(cubePrefab) as GameObject;
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
