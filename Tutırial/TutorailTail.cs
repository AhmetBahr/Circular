using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorailTail : MonoBehaviour
{
    [SerializeField] public int currentScore;
    [SerializeField] public int scoreForheard;

    [SerializeField] private int addTailInt;
    [SerializeField] protected int addHeadInt;

    [SerializeField] public float tailRender;
    [SerializeField] private TrailRenderer trRen;

    [SerializeField] private GameObject[] blurs;

    //  ManuScript Mnscrp;
    TutorialPlayer plyrMov;

    private void Start()
    {
    //    Mnscrp = GameObject.Find("Manager").GetComponent<ManuScript>();
        plyrMov = GameObject.Find("Player").GetComponent<TutorialPlayer>();

        currentScore = 0;
    }

    private void Update()
    {
        TailController();

    }

    private void TailController()
    {
        if (currentScore >= addTailInt)
        {
            currentScore = 0;
            AddTail();
        }
        if (scoreForheard >= addHeadInt)
        {
            scoreForheard = 0;
            plyrMov.TakeShield();
        }

        if (tailRender >= 1.92f)
        {
            tailRender = 0;
            trRen.time = tailRender;
            //Animation
        }


        if (scoreForheard == (addHeadInt - 2))
        {
            blurs[0].SetActive(true);
        }
        if (scoreForheard == (addHeadInt - 1))
        {
            blurs[1].SetActive(true);
        }
        if (scoreForheard == 0)
        {
            blurs[0].SetActive(false);
            blurs[1].SetActive(false);

        }



    }

    public void AddTail()
    {
        tailRender += 0.32f;
        trRen.time = tailRender;
    }

    public void TailRemove()
    {
        if (tailRender >= 0)
        {
            tailRender -= 0.16f;
        }
        trRen.time = tailRender;
    }
}
