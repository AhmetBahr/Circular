using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScMenu : MonoBehaviour
{
    public float scealOfTime = 1.0f;


    public Image BuIste;

    private bool Showit = false;
    private float transition = 0.5f;


    public void Start()
    {
        gameObject.SetActive(false);

    }



    public void Update()
    {

        if (!Showit)
            return;


    }

    public void TrunOffThis()
    {
        gameObject.SetActive(false);
        Showit = false;
    }

    public void ToogleMenu(float WeScore)
    {


        gameObject.SetActive(true);
        Showit = true;
    }
}
