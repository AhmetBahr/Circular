using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    AdmobManager admob;

    private void Awake()
    {
        admob = Object.FindObjectOfType<AdmobManager>();
    }

    private void Start()
    {
        admob.ShowBanner();
    }

}
