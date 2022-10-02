using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPause = false;
    public GameObject PauseMenuUI;





    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPause)
            {
                Resume();
            }   
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
    
        PauseMenuUI.SetActive(false);

        GameIsPause = false;
    }
    public void Pause()
    {

        PauseMenuUI.SetActive(true);
        GameIsPause = true;

    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);

    }



}
