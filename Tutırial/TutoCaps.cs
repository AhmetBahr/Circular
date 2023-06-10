using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoCaps : MonoBehaviour
{
    private float speed = 1f;
    [SerializeField] private Rigidbody2D rb;




    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -speed);
    }




}
