using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Basic : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private float speed = 1.5f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private bool isX;

    private float RandomInt;

    private float xAngle, yAngle, zAngle;

   




    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -speed);
       
        if(isX)
        enemy.transform.Rotate( new Vector3(0, 0, 90)); 
            
            
    }

    void Update()
    {

        Destroy(gameObject, 15);

    }



}
