using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointScript : MonoBehaviour
{
    [SerializeField] private GameObject point;
    [SerializeField] private float speed = 1.5f;
    [SerializeField] private Rigidbody2D rb;

    private float zAngle;

    VibratorBT Referans_Vibra;


    private void Start()
    {
        Referans_Vibra = GameObject.FindWithTag("Manager").GetComponent<VibratorBT>();
    } 

    void Update()
    {

        if (Time.frameCount % 3 == 0)
        {
            Rotate();
            Moveing();
        }
    }

    void Rotate()
    {
        point.transform.DORotate(new Vector3(0, 0, zAngle + 45), 1, RotateMode.WorldAxisAdd);
    }

    void Moveing()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -speed);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            if (Referans_Vibra.vibra == true)
            {
                Vibrator.Vibrate(100);
            }

            gameObject.SetActive(false);

        }


    
    }
}
