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

	private int gem;
	public int score;

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

	[Header("Tutorial")]
	[SerializeField] private RectTransform tutorialMenu;
	[SerializeField] private RectTransform tutorialSettings;


	[Header("Spawner")]
	[SerializeField] private GameObject spawn1;
	[SerializeField] private GameObject spawn2;
	[SerializeField] private GameObject spawn3;
	[SerializeField] private GameObject spawn4;
	[SerializeField] private GameObject spawn5;

	[Header("Referans")]
	PauseControl pauseCont;
	PoolingEnemy s1;
	PoolingEnemy_2 S2;
	PoolingEnemy_3 S3;
	PoolingEnemy_4 S4;
	PoolingEnemy_5 S5;
	public RewardAdmob AM;
	Tail tail;



	void Start()
	{

		int score = 0;

		updateHighScoreText();


		pauseCont = GameObject.Find("Manager").GetComponent<PauseControl>();

		s1 = GameObject.Find("EnemySpawner_1").GetComponent<PoolingEnemy>();
		S2 = GameObject.Find("EnemySpawner_2").GetComponent<PoolingEnemy_2>();
		S3 = GameObject.Find("EnemySpawner_3").GetComponent<PoolingEnemy_3>();
		S4 = GameObject.Find("EnemySpawner_4").GetComponent<PoolingEnemy_4>();
		S5 = GameObject.Find("EnemySpawner_5").GetComponent<PoolingEnemy_5>();



		tail = GameObject.Find("Tail").GetComponent<Tail>();


		gems.text = PlayerPrefs.GetInt("Gems",0).ToString();

		tutoCanvas();

		if (PlayerPrefs.GetInt("Tutorial") > 2)
		{
		   tutorialMenu.gameObject.SetActive(false);
		   tutorialSettings.gameObject.SetActive(false);

		}
	}


	#region Panael
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
		PauseCanvas.DOAnchorPos(new Vector2(-850, 0), 0.8f);
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
		pauseCont.ResumeGame();
		SceneManager.LoadScene("Circular");


	}

	IEnumerator reStart()
	{
		yield return new WaitForSeconds(0.2f);
		pauseCont.ResumeGame();
		SceneManager.LoadScene("Circular");

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
		SettingsCanvas.DOAnchorPos(new Vector2(-1200, 0), 0.5f);
		MainMenu.DOAnchorPos(new Vector2(0, 0), 0.8f);
		TextCanvas.DOAnchorPos(new Vector2(0, -0), 0.8f);
	}

	public void death()
	{
		PauseCanvas.DOAnchorPos(new Vector2(-1100, 0), 0.8f);
		hearthCanvas.DOAnchorPos(new Vector2(1600, 0), 0.8f);
		DeathMenu.DOAnchorPos(new Vector2(0, 0), 0.8f);
	}

	#endregion

	#region Scoreup
	public void scoreUp()
	{

		score++;
		tail.currentScore++;
		tail.scoreForheard++;
		//PlayText.text = score.ToString();
		PlayText.SetText(score);
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

	void updateHighScoreText()
	{
		Hgscore.text = $"{PlayerPrefs.GetInt("Score", 0)}";
		Death_Hgscore.text = $"{PlayerPrefs.GetInt("Score", 0)}";

	}

	#endregion


	#region Shop
	public void Shop()
	{
		PlayerPrefs.SetInt("Gems", PlayerPrefs.GetInt("Gems") - 50); //ÜRÜN TEXT AZALTMASI 
		gems.text = (PlayerPrefs.GetInt("Gems")).ToString();
	}

	public void ekranYenileme()
	{
		gems.text = PlayerPrefs.GetInt("Gems", 0).ToString();

	}

	#endregion

	#region Addmob
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

	#endregion


	#region Totorial
	private void tutoCanvas()
	{
		if (PlayerPrefs.GetInt("Tutorial") < 1)
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

	#endregion


	#region Spawner Controller

	private void SpawnerCont()
	{
		if (score >= 8 && score <= 18)
		{
			s1.isStart = false;
			S2.isStart = true;
			s1.StartThinkgs();

		}
		if (score >=19 && score <=30)
		{

			S2.isStart = false;
			S3.isStart = true;
			S2.StartThinkgs();
		}
		if(score >= 31 && score <= 44)
		{
			S3.isStart = false;
			S4.isStart = true;
			S3.StartThinkgs();

		}
		if ( score >= 45 && score <= 60)
		{
			S4.isStart = false;
			S5.isStart = true;
			S4.StartThinkgs();

		}


	}


	#endregion



}

