using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;


public class PlayerMovie : MonoBehaviour
{
    float timeCounter = 0;
    public float speed = 2.5f;
    float width = 1.5f;
    float height = 1.5f;
    int yon = 1;
    int can;
    int bgInt;
    int gems;


    public int Score;
    //public TMP_Text ScoreText;
    // public Text ScoreText;
    BackGroundColor referanskod1;
    ManuScript referanskod2;


    bool isDeath;

    void Start()
    {
    //    referanskod1 = GameObject.Find("Background1").GetComponent<BackGroundColor>();
        referanskod2 = GameObject.Find("Manager").GetComponent<ManuScript>();
        Score = 0;
        can = 2;
        bgInt = 0;
    }


    void Update()
    {
       

        if (yon == 1)
            timeCounter += Time.deltaTime * speed;

        if (yon == -1)
            timeCounter += Time.deltaTime * speed * -1;


        float x = Mathf.Cos(timeCounter) * width;
        float y = Mathf.Sin(timeCounter) * height;
        float z = -3;

        transform.position = new Vector3((17 * x) / 20, (17 * y / 20), z);

        if (Input.GetKeyDown(KeyCode.W))
        {
            yon *= -1;

        }

        if (Input.GetMouseButtonDown(0))
        {
            yon *= -1;
            PlayerSount.PlayerSound("swing");

        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            SkorUp();
            
        }


        if (bgInt == 2)
        {
            bgInt = 0;
            Debug.Log("bg1 " + bgInt);
         //   referanskod1.BgRandomColor();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Point")
        {
            SkorUp();
            PlayerSount.PlayerSound("point");
         
        }


        if (collision.transform.tag == "Enemy")
        {
            deat();
            PlayerSount.PlayerSound("expoo");
        }
    }

    

    public void deat()
    {
        referanskod2.death();
        Destroy(gameObject);
            
       
    }


    public void SkorUp()
    {
        // bgInt++;
        Score++;
        referanskod2.scoreUp();
    }

}
