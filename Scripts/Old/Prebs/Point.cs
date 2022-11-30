using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 scBount;
    public int sure;
    public float dom = 2f; 


    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, 0);
        scBount = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

    }

    void Update()
    {
        if (transform.position.x < scBount.x)
        {
            Destroy(this.gameObject, 7);
        }

        Vector3 rot = transform.eulerAngles;
         transform.rotation = Quaternion.Euler(rot.x, rot.y, rot.z +(-dom));



    }






}
