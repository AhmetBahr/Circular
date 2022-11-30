using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MarketManager : MonoBehaviour
{

    bool PanelOp;
    public GameObject panel;
    public int mon;
    public GameObject karakter;

    public bool k1b;
    public bool k2b;
    public bool k3b;

    public Sprite k1s;
    public Sprite k2s;
    public Sprite k3s;
    public Sprite tick;

    public Image k2ds;
    public Image k3ds;

    public Text MoneyTx;

    public void k1()
    {
        karakter.GetComponent<SpriteRenderer>().sprite = k1s;
    }


    public void k2()
    {
        if (!k2b && mon >= 10 )
        {
            mon = mon - 10;
            karakter.GetComponent<SpriteRenderer>().sprite = k2s;
            k2ds.sprite = tick;
            k2b = true;
        }
        if (k2b)
            karakter.GetComponent<SpriteRenderer>().sprite = k2s;

    }

    public void k3()
    {
        if (!k3b && mon >= 10)
        {
            mon = mon - 10;
            karakter.GetComponent<SpriteRenderer>().sprite = k3s;
            k2ds.sprite = tick;
            k3b = true;
        }
        if (k3b)
            karakter.GetComponent<SpriteRenderer>().sprite = k3s;

    }


    public void marketOp()
    {
        PanelOp = !PanelOp;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (PanelOp)
        {
            panel.SetActive(true);
        }
        else
        {
            panel.SetActive(false);
        }

        MoneyTx.text = mon.ToString();
        
    }
}
