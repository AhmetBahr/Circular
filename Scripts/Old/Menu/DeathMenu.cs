using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class DeathMenu : MonoBehaviour
{
    public Text score;
    public Text Hgscore ;
    public Image BgImage;

    private bool isShow = false;
    private float transition = 0.5f;
    private float startTime;

    public MenuSc MS;
    public ScMenu MS2;

    void Start()
    {
        gameObject.SetActive(false);
        Hgscore.text = ((int)PlayerPrefs.GetFloat("HighScore")).ToString();


    }

    void Update()
    {
        if (!isShow)
            return;

        transition += Time.deltaTime;
        BgImage.color = Color.Lerp(new Color(0, 0, 0, 0), Color.gray, transition);

    }

    public void ToogleMenu(float WeScore)
    {


        gameObject.SetActive(true);
        score.text = ((int)WeScore).ToString();
        isShow = true;
    }

    public void Restart()
    {
        MS.ShowThis();
        MS2.TrunOffThis();

    }
    public void Menu()
    {
        startTime = Time.time;
        SceneManager.LoadScene(0);

    }


}
