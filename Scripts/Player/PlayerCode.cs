using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class PlayerCode : MonoBehaviour 
{
    float timeCounter = 0;
    public float speed = 2.5f;
    float width = 1.5f;
    float height = 1.5f;
    int yon = 1;

    

    public int say;

    public int Money;


    public int WeScore;
    public Text WeText;

    public DeathMenu dtmenu;
    public RandomColor rdmColor;
    public GecisAdmob AdMob;



    public bool isDeat = false;



    void Start()
    {
        say = 0;
        WeScore = 0;
    }


    void Update()
    {
        if (isDeat)
        {
            Debug.Log("Öldü");

            return;
        }

       
       

        if(yon == 1)
        timeCounter += Time.deltaTime * speed;
       
        if (yon == -1)
            timeCounter += Time.deltaTime * speed*-1;


            float x = Mathf.Cos(timeCounter) * width;
            float y = Mathf.Sin(timeCounter) * height;
            float z = 0;

            transform.position = new Vector3((15*x)/20, (15*y/20), z);

        if (Input.GetKeyDown(KeyCode.W))
        {
            yon *= -1;

            PlayerSount.PlayerSound("W");
        }

        if (Input.GetMouseButtonDown(0))
        {
            yon *= -1;

            PlayerSount.PlayerSound("W");
        }



        if (say == 5)
        {

            PlayerSount.PlayerSound("C");
            rdmColor.RandomColors();
            say = 0;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            SkorUp();

        }

    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Point")
        {
            PlayerSount.PlayerSound("P");
            SkorUp();
            Destroy(collision.gameObject);
        }


        if (collision.transform.tag == "Block")
        {
            PlayerSount.PlayerSound("D");
            deat();
        }

    }




    public void deat()
    {
        isDeat = true;
        if (PlayerPrefs.GetFloat("HighScore") < WeScore)
        {
            PlayerPrefs.SetFloat("HighScore", WeScore);
        }
        if (  0 < Money)
        {
            PlayerPrefs.SetFloat("Money", PlayerPrefs.GetFloat("Money",Money) + Money);

           
        }



        dtmenu.ToogleMenu(WeScore);

        AdMob.ShowInterstitial();

        Destroy(gameObject);
        
    }


    public void SkorUp()
    {
      

        Money++;
        WeScore++;
        WeText.text = WeScore.ToString();
        say++;

    }




}
