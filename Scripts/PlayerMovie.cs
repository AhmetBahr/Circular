using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerMovie : MonoBehaviour
{
    float timeCounter = 0;
    public float speed = 2.5f;
    float width = 1.5f;
    float height = 1.5f;
    int yon = 1;
    int can;
    int bgInt;



    public int Score;
    //public TMP_Text ScoreText;
    // public Text ScoreText;
    BackGroundColor referanskod1;
    ManuScript referanskod2;


    bool isDeath;

    void Start()
    {
        referanskod1 = GameObject.Find("Background1").GetComponent<BackGroundColor>();
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

        transform.position = new Vector3((15 * x) / 20, (15 * y / 20), z);

        if (Input.GetKeyDown(KeyCode.W))
        {
            yon *= -1;

        }

        if (Input.GetMouseButtonDown(0))
        {
            yon *= -1;

        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            SkorUp();
            
        }


        if (bgInt == 2)
        {
            bgInt = 0;
            Debug.Log("bg1 " + bgInt);
            referanskod1.BgRandomColor();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Point")
        {
            SkorUp();
         
        }


        if (collision.transform.tag == "Block")
        {
            deat();
        }
    }

    public void deat()
    {
        can--;
        if (PlayerPrefs.GetFloat("HighScore") < Score )
        {
            PlayerPrefs.SetFloat("HighScore", Score );
        }

        if (can == 0)
        {
            referanskod2.death();
            Destroy(gameObject);
            
        }
    }


    public void SkorUp()
    {
        bgInt++;

        referanskod2.scoreUp();
    }

}
