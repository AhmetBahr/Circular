using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuSc : MonoBehaviour
{
    public float scealOfTime = 1.0f;
    public Text Hgscore;


    public Image StrMenu;

    private bool Showit = true;
    private float transition = 0.5f;


    public void Start()
    {
     //   gameObject.SetActive(true);

        Hgscore.text = ((int)PlayerPrefs.GetFloat("HighScore")).ToString();
       


    }


    public void toGame()
    {
        SceneManager.LoadScene(1);

    }

    public void Update()
    {


     

        if (!Showit)
            return;

        transition -= Time.deltaTime;
        StrMenu.color = Color.Lerp(new Color(0, 0, 0, 0), Color.gray, transition);

    }

    public void ShowThis()
    {
        gameObject.SetActive(true);
        Showit = true;
    }

    public void ToogleMenu(float WeScore)
    {


        gameObject.SetActive(false);
        Showit = false;
    }

}
