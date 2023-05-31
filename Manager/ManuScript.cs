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

    public RectTransform MainMenu, MarketMenu,TextCanvas,DeathMenu,PauseCanvas, SettingsCanvas;
    public TMP_Text Hgscore;
    public TMP_Text Death_Hgscore;
    public TMP_Text PlayText;
    public TMP_Text gems;

    public Button tapToPlay;



    int gem;
    public int score;

    PlayerSpawner referanskod3;
    PauseControl Referasn_PauseCont;

    public RewardAdmob AM;



    void Start()
    {
        int score = 0;
        updateHighScoreText();
        Referasn_PauseCont = GameObject.Find("Manager").GetComponent<PauseControl>();
        Referasn_PauseCont = GameObject.Find("Manager").GetComponent<PauseControl>();


        gems.text = PlayerPrefs.GetInt("Gems",0).ToString();


    }

    void Update()
    {

    }

    public void MarketMenuOn()
    {
        MainMenu.DOAnchorPos(new Vector2(0, -2500), 0.8f);
        MarketMenu.DOAnchorPos(new Vector2(0, 0), 0.8f);
        TextCanvas.DOAnchorPos(new Vector2(0, 2500), 0.8f);
        SettingsCanvas.DOAnchorPos(new Vector2(-1100, 0), 0.8f);

    }
    public void MarketMenuOff()
    {
        MainMenu.DOAnchorPos(new Vector2(0, 0), 0.8f);
        MarketMenu.DOAnchorPos(new Vector2(0, -2500), 0.8f);
        TextCanvas.DOAnchorPos(new Vector2(0, -0), 0.8f);

    }

    public void startGame()
    {
        MainMenu.DOAnchorPos(new Vector2(0, -2500), 0.8f);
        TextCanvas.DOAnchorPos(new Vector2(0, 2500), 0.8f);
        PauseCanvas.DOAnchorPos(new Vector2(-850, 0),0.8f);
        SettingsCanvas.DOAnchorPos(new Vector2(-1100, 0), 0.8f);
        tapToPlay.interactable = false;


    }

    public void startMenu()
    {
        MainMenu.DOAnchorPos(new Vector2(0, 0), 0.8f);
        TextCanvas.DOAnchorPos(new Vector2(0, 0), 0.8f);
      

    }

    public void reklamIzle()
    {
        StartCoroutine(reStart());
    }

    public void reStartGame()
    {
        Referasn_PauseCont.ResumeGame();
        SceneManager.LoadScene("Circular");


    }

    IEnumerator reStart()
    {
        yield return new WaitForSeconds(0.2f);
        Referasn_PauseCont.ResumeGame();
        SceneManager.LoadScene("Circular");

    }

    public void death()
    {
        PauseCanvas.DOAnchorPos(new Vector2(-1100, 0), 0.8f);
        DeathMenu.DOAnchorPos(new Vector2(0, 0), 0.8f);
    }
    public void spawn()
    {
        DeathMenu.DOAnchorPos(new Vector2(0, -2377), 0.8f);
        referanskod3.startPlayer();

    }

    public void PausePanelOff()
    {
        PauseCanvas.DOAnchorPos(new Vector2(-1100, 0), 0.8f);

    }

    public void settingsOn()
    {
        SettingsCanvas.DOAnchorPos(new Vector2(0, 0), 0.5f);

    }

    public void settingsOff()
    {
        SettingsCanvas.DOAnchorPos(new Vector2(-1200,0), 0.5f);

    }

    public void scoreUp()
    {
  
        score++;
        PlayText.text = score.ToString();
        PlayerPrefs.SetInt("Gems", PlayerPrefs.GetInt("Gems", 0) + 1);


        if (score > PlayerPrefs.GetInt("Score", 0))
        {
            PlayerPrefs.SetInt("Score", score);
            updateHighScoreText();

    //        Debug.Log("Score" + score);
        }

    }


    public void scoreUp2()
    {

        score += 2;
        PlayText.text = score.ToString();
        PlayerPrefs.SetInt("Gems", PlayerPrefs.GetInt("Gems", 0) + 2);


        if (score > PlayerPrefs.GetInt("Score", 0))
        {
            PlayerPrefs.SetInt("Score", score);
            updateHighScoreText();

        }

    }


    public void Shop()
    {
        PlayerPrefs.SetInt("Gems", PlayerPrefs.GetInt("Gems") - 50); //ÜRÜN TEXT AZALTMASI 
        gems.text = (PlayerPrefs.GetInt("Gems")).ToString();
    }

    void updateHighScoreText()
    {
        Hgscore.text = $"{PlayerPrefs.GetInt("Score", 0)}";
        Death_Hgscore.text = $"{PlayerPrefs.GetInt("Score", 0)}";

    }

    public void ekranYenileme()
    {
        gems.text = PlayerPrefs.GetInt("Gems", 0).ToString();

    }

    public void OnClickConfirmWatch()
    {
        //ShowVideo
        AM.ShowRewardedAd(); 
    }

    public void OnUserEarnedReward()
    {
        //Kullanýcýya 20Gems
        PlayerPrefs.SetInt("Gems", PlayerPrefs.GetInt("Gems") + 20); // 20 gems ödül verildi
        
        gems.text = (PlayerPrefs.GetInt("Gems")).ToString();

        Debug.Log("Get gems");
    }

}
