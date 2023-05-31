using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallSelect : MonoBehaviour
{
    public GameObject[] ballSkin;
    public Ball[] balls;

    public Button[] buttons;
    public Button unlockButton;

    int SelectedBall;

    ManuScript ref1;

    private void Awake()
    {
        int counter = 0;
        foreach(Ball b in balls)
        {
            b.index = counter;
            if (counter == 0)
                b.isLock = false;
            else
            {
                if (PlayerPrefs.GetInt(b.index.ToString(), 1) == 1)
                    b.isLock = true;
                else
                    b.isLock = false;
                buttons[b.index].interactable = !b.isLock;
            }

            counter++;
        }
    }

    void Start()
    {
        ref1 = GameObject.Find("Manager").GetComponent<ManuScript>();

        SelectedBall = PlayerPrefs.GetInt("SelectedBall", 0);
        foreach(GameObject skin in ballSkin)
        {
            skin.SetActive(false);
        }
        ballSkin[SelectedBall].SetActive(true);

    }

    void Update()
    {
        if (PlayerPrefs.GetInt("Gems") < 50)  //ÜRÜN FÝYATI
            unlockButton.interactable = false;
        else 
            unlockButton.interactable = true;   

        
    }

    public void ChangeBall(int index)
    {
        ballSkin[SelectedBall].SetActive(false);
        SelectedBall = index;
        ballSkin[SelectedBall].SetActive(true) ;
        PlayerPrefs.SetInt("SelectedBall", index);
    }
    public void Unlock()
    {
      List<Ball> lockedBalls = new List<Ball>();
        foreach(Ball b in balls)
        {
            if(b.isLock)
                lockedBalls.Add(b);
        }
        if (lockedBalls.Count == 0)
            return;

        int randomBall = Random.Range(0, lockedBalls.Count);

        int ballIndex = lockedBalls[randomBall].index;
        balls[ballIndex].isLock = false;
        buttons[ballIndex].interactable = true;
        PlayerPrefs.SetInt(ballIndex.ToString(), 0);
        ref1.Shop();

        buttons[ballIndex].onClick.Invoke();
    }

}
