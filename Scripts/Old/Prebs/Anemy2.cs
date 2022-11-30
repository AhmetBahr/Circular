using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anemy2 : MonoBehaviour
{
    public float speed = 10.0f;
    private Rigidbody2D rb;
    private Vector2 scBount;
    public int sure;


    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, 0)*-1;
        scBount = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        sure = 0;
    }

    void Update()
    {
        if (transform.position.x < scBount.x)
        {
            Destroy(this.gameObject, 5);
        }


    }
}
