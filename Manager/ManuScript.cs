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
    [Header("Panels")]
    [SerializeField] private RectTransform MainMenu;
    [SerializeField] private RectTransform MarketMenu;
    [SerializeField] private RectTransform TextCanvas;
    [SerializeField] private RectTransform DeathMenu;
    [SerializeField] private RectTransform PauseCanvas;
    [SerializeField] private RectTransform SettingsCanvas;
    [SerializeField] private RectTransform hearthCanvas;

    [Header("Texts")]
    public TMP_Text Hgscore;
    public TMP_Text Death_Hgscore;
    public TMP_Text PlayText;
    public TMP_Text gems;

    [Header("Button")]
    public Button tapToPlay;

    private int gem;
    public int score;


    [Header("Referans")]
    PlayerSpawner referanskod3;
    PauseControl Referasn_PauseCont;
    public RewardAdmob AM;
    Tail tail;



    [Header("Tutorial")]
    [SerializeField] private RectTransform tutorialMenu;
    [SerializeField] private RectTransform tutorialSettings;


    [Header("Spawner")]
    [SerializeField] private GameObject spawn1;
    [SerializeField] private GameObject spawn2;
    [SerializeField] private GameObject spawn3;
    [SerializeField] private GameObject spawn4;
    [SerializeField] private GameObject spawn5;

    PoolingEnemy   s1;
    PoolingEnemy_2 S2;
    PoolingEnemy_3 S3;
    PoolingEnemy_4 S4;
    PoolingEnemy_5 S5;



    void Start()
    {

        int score = 0;
        updateHighScoreText();
        Referasn_PauseCont = GameObject.Find("Manager").GetComponent<PauseControl>();

        s1 = GameObject.Find("EnemySpawner_1").GetComponent<PoolingEnemy>();




        tail = GameObject.Find("Tail").GetComponent<Tail>();


        gems.text = PlayerPrefs.GetInt("Gems",0).ToString();

        tutoCanvas();

        if (PlayerPrefs.GetInt("Tutorial") > 2)
        {
           tutorialMenu.gameObject.SetActive(false);
           tutorialSettings.gameObject.SetActive(false);

        }
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
        hearthCanvas.DOAnchorPos(new Vector2(800, 0), 0.8f);
        SettingsCanvas.DOAnchorPos(new Vector2(-1100, 0), 0.8f);
        tapToPlay.interactable = false;


        StartCoroutine(disActivePanels());
    }

    IEnumerator disActivePanels()
    {
        yield return new WaitForSeconds(1.5f);


        MainMenu.gameObject.SetActive(false);
        TextCanvas.gameObject.SetActive(false);
        SettingsCanvas.gameObject.SetActive(false);
        MarketMenu.gameObject.SetActive(false);




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
        hearthCanvas.DOAnchorPos(new Vector2(1600, 0), 0.8f);
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
        SettingsCanvas.DOAnchorPos(new Vector2(0, 0), 0.8f);
        MainMenu.DOAnchorPos(new Vector2(0, -2500), 0.8f);
        TextCanvas.DOAnchorPos(new Vector2(0, 2500), 0.8f);
    }

    public void settingsOff()
    {
        SettingsCanvas.DOAnchorPos(new Vector2(-1200,0), 0.5f);
        MainMenu.DOAnchorPos(new Vector2(0, 0), 0.8f);
        TextCanvas.DOAnchorPos(new Vector2(0, -0), 0.8f);
    }

    public void scoreUp()
    {
  
        score++;
        tail.currentScore++;
        tail.scoreForheard++;
        PlayText.text = score.ToString();
        PlayerPrefs.SetInt("Gems", PlayerPrefs.GetInt("Gems", 0) + 1);


        if (score > PlayerPrefs.GetInt("Score", 0))
        {
            PlayerPrefs.SetInt("Score", score);
            updateHighScoreText();

        }
        SpawnerCont();

    }

    public void scoreUp5()
    {
        PlayerPrefs.SetInt("Gems", PlayerPrefs.GetInt("Gems", 0) + 10);
        //Gem animation

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



    private void tutoCanvas()
    {
        if(PlayerPrefs.GetInt("Tutorial") < 1)
        {
            tutorialMenu.DOAnchorPos(new Vector2(0, 0), 0.2f);

        }
    }
    public void tutorialSettingsButton()
    {

        tutorialMenu.DOAnchorPos(new Vector2(1500, 0), 0.8f);
        tutorialSettings.DOAnchorPos(new Vector2(0, 0), 0.8f);
        MainMenu.DOAnchorPos(new Vector2(0, -2500), 0.8f);
        TextCanvas.DOAnchorPos(new Vector2(0, 2500), 0.8f);
        SettingsCanvas.DOAnchorPos(new Vector2(0, 0), 0.8f);


    }


    public void UploadTutorial()
    {
        PlayerPrefs.SetInt("Tutorial", 5);
        SceneManager.LoadScene("Tutorial");
    }


    private void SpawnerCont()
    {
        if(score >= 5  &&  score <= 8)
        {
            s1.isStart = false;
            spawn2.SetActive(true);
            S2 = GameObject.Find("EnemySpawner_2").GetComponent<PoolingEnemy_2>();
        }
        if (score >= 9 && score <= 12)
        {

            S2.isStart = false;
            spawn3.SetActive(true);
        }


    }

}


/*
  
       
        S3 = GameObject.Find("EnemySpawner_3").GetComponent<PoolingEnemy_3>();
        S4 = GameObject.Find("EnemySpawner_4").GetComponent<PoolingEnemy_4>();
        S5 = GameObject.Find("EnemySpawner_5").GetComponent<PoolingEnemy_5>();


*/