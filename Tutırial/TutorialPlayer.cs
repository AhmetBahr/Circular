using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class TutorialPlayer : MonoBehaviour
{
    float timeCounter = 0;
    public float speed = 2.5f;
    float width = 1.5f;
    float height = 1.5f;
    int yon = 1;
    int Score;

    [SerializeField] public TMP_Text ScoreText;
    [SerializeField] public GameObject SquearText;
    [SerializeField] public GameObject CapsulText;
    [SerializeField] public GameObject TapText;


    [SerializeField] private RectTransform DeathMenu;


    TutorailTail tutoTail;

    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;

    [Header("Health")]
    [SerializeField] private int health;
    [SerializeField] private int maxHealth;
    [SerializeField] private GameObject[] hearts;

    void Start()
    {
        tutoTail = GameObject.Find("Tail").GetComponent<TutorailTail>();


    }

    // Update is called once per frame
    void Update()
    {
        if (yon == 1)
            timeCounter += Time.deltaTime * speed;

        if (yon == -1)
            timeCounter += Time.deltaTime * speed * -1;


        float x = Mathf.Cos(timeCounter) * width;
        float y = Mathf.Sin(timeCounter) * height;
        float z = -3;

        transform.position = new Vector3((13 * x) / 20, (13 * y) / 20, z);


        ScoreText.text = Score.ToString();


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        heartSystem();
    }

    public void Tap()
    {
        yon *= -1;

    }

    public void deat()
    {
        if (health <= 0)
        {
            DeathMenu.DOAnchorPos(new Vector2(0, 0), 0.8f);
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }

        health--;
        tutoTail.scoreForheard = 0;

        tutoTail.TailRemove();

    }

    private void heartSystem()
    {
        for (int i = 0; i < maxHealth; i++)
        {
            hearts[i].SetActive(false);
        }
        for (int i = 0; i < health; i++)
        {
            hearts[i].SetActive(true);
        }
    }

    public void TakeShield()
    {


        health++;
        Debug.Log(health);
    }
    public void SkorUp()
    {
        tutoTail.currentScore++;
        tutoTail.scoreForheard++;
        Score++;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Point"))
        {
            SkorUp();

        }

        if(collision.CompareTag("Tuto"))
        {
            TextsActiveGems();
            SlowTime();

        }
        if (collision.CompareTag("Tuto2"))
        {
            TextActivecaps();
            SlowTime();

        }
        if (collision.CompareTag("Tut"))
        {
            SlowTime();
            TextActiveTap();
        }



        if (collision.CompareTag("TutoExit"))
        {
            TextsDisctive();

        }

        if (collision.CompareTag("Enemy"))
        {
            deat();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Tuto"))
        {
            NormalTime();
        }

        if (collision.CompareTag("Tuto2"))
        {
            NormalTime();

        }
        if (collision.CompareTag("Tut"))
        {
            NormalTime();

        }
    }


    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void ExitTuto()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Circular");
    }

    public void Restart()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Tutorial");
    }
    private void SlowTime()
    {
        Time.timeScale = 0.4f;

    }

    private void NormalTime()
    {
        Time.timeScale = 1f;

    }

    private void TextsActiveGems()
    {
        SquearText.SetActive(true);
    }

    private void TextActivecaps()
    {
        CapsulText.SetActive(true);

    }
    private void TextActiveTap()
    {
        TapText.SetActive(true);

    }

    private void TextsDisctive()
    {
        SquearText.SetActive(false);
        CapsulText.SetActive(false);
        TapText.SetActive(false);
    }
}
