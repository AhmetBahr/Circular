using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointScript : MonoBehaviour
{
    [SerializeField] private GameObject point;
    private float speed = 1.5f;
    [SerializeField] private Rigidbody2D rb;
    //private float backspeed = -5f;
    private float turnInt;
    private float RandomInt;

    private float xAngle, yAngle, zAngle;

    VibratorBT Referans_Vibra;


    void Start()
    {
        Referans_Vibra = GameObject.Find("Manager").GetComponent<VibratorBT>();
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, 0);
    }

    void Update()
    {

            Rotate();
     
       

        Destroy(gameObject, 6);

    }

    void Rotate()
    {
        turnInt = 0;
        point.transform.DORotate(new Vector3(0, 0, zAngle + 45), 1, RotateMode.WorldAxisAdd);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Destroy(gameObject);
            if (Referans_Vibra.vibra == true)
            {
                Vibrator.Vibrate(100);
           //     Debug.Log("Titrettin beni");
            }
            else
            {

            }

          
        }


    
    }
}
