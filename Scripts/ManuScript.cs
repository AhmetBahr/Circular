using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ManuScript : MonoBehaviour
{

    public RectTransform MainMenu, MarketMenu,TextCanvas,DeathMenu;
    public TMP_Text Hgscore;
    public TMP_Text PlayText;
    public TMP_Text gems;

    int gem;
    int score;

    PlayerSpawner referanskod3;


    void Start()
    {
        int score = 0;
        updateHighScoreText();
        referanskod3 = GameObject.Find("Spawner").GetComponent<PlayerSpawner>();
        gems.text = PlayerPrefs.GetInt("Gems",0).ToString();


    }

    void Update()
    {

    }

    public void MarketMenuOn()
    {
        MainMenu.DOAnchorPos(new Vector2(0, -2222), 0.8f);
        MarketMenu.DOAnchorPos(new Vector2(0, 0), 0.8f);
        TextCanvas.DOAnchorPos(new Vector2(0, 2500), 0.8f);

    }
    public void MarketMenuOff()
    {
        MainMenu.DOAnchorPos(new Vector2(0, 0), 0.8f);
        MarketMenu.DOAnchorPos(new Vector2(0, -2500), 0.8f);
        TextCanvas.DOAnchorPos(new Vector2(0, -0), 0.8f);

    }

    public void startGame()
    {
        MainMenu.DOAnchorPos(new Vector2(0, -2222), 0.8f);
        TextCanvas.DOAnchorPos(new Vector2(0, 2500), 0.8f);
    }

    public void startMenu()
    {
        MainMenu.DOAnchorPos(new Vector2(0, 0), 0.8f);
        TextCanvas.DOAnchorPos(new Vector2(0, 0), 0.8f);
    }

    public void reStartGame()
    {
        SceneManager.LoadScene("Remake");
    }

    public void death()
    {

   
     
        DeathMenu.DOAnchorPos(new Vector2(0, 0), 0.8f);

    }
    public void spawn()
    {
        DeathMenu.DOAnchorPos(new Vector2(0, -2377), 0.8f);
        referanskod3.startPlayer();

    }

    public void scoreUp()
    {
  
        score++;
        Debug.Log("Anlýk" + score);
        PlayText.text = score.ToString();
       // gem++;
        PlayerPrefs.SetInt("Gems", PlayerPrefs.GetInt("Gems", 0) + 1);


        if (score > PlayerPrefs.GetInt("Score", 0))
        {
            PlayerPrefs.SetInt("Score", score);
            updateHighScoreText();

            Debug.Log("Score" + score);
        }

    }

    public void Shop()
    {
        PlayerPrefs.SetInt("Gems", PlayerPrefs.GetInt("Gems") - 50);
        gems.text = (PlayerPrefs.GetInt("Gems")).ToString();

    }

    void updateHighScoreText()
    {
        Hgscore.text = $"{PlayerPrefs.GetInt("Score", 0)}";
    }


}
