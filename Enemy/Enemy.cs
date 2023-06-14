using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private float speed = 1.5f;
    [SerializeField] private Rigidbody2D rb;

    private float turnInt;
    private float RandomInt;

    private float xAngle, yAngle, zAngle;


    void RandomSayý()
    {
        RandomInt = Random.Range(2, 6);
    }


    void Update()
    {
        turnInt += Time.deltaTime;

        if (turnInt >= RandomInt)
        {
            
                Rotate();
                RandomSayý();
            
        }


        if (Time.frameCount % 3 == 0)
            moveing();

    }

    void Rotate()
    {
        turnInt = 0;
        enemy.transform.DORotate(new Vector3(0, 0, zAngle-90), 1, RotateMode.WorldAxisAdd);
    }


    private void moveing()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -speed);

    }


}
