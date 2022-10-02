using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSount : MonoBehaviour
{

    public static AudioClip Wsound,Dsound,Psound,Csound,C2sound;
    static AudioSource audiosoruce;

    void Start()
    {

        Wsound = Resources.Load<AudioClip>("W2");
        Psound = Resources.Load<AudioClip>("Point");
        Dsound = Resources.Load<AudioClip>("Dead");
        Csound = Resources.Load<AudioClip>("Change");
        C2sound = Resources.Load<AudioClip>("Click");

        audiosoruce = GetComponent<AudioSource>();

    }

    public static void PlayerSound(string clip)
    {

        switch (clip)
        {
            case "W":
                audiosoruce.PlayOneShot(Wsound);
                break;
            case "D":
                audiosoruce.PlayOneShot(Dsound);
                break;
            case "P":
                audiosoruce.PlayOneShot(Psound);
                break;
            case "C":
                audiosoruce.PlayOneShot(Csound);
                break;
            case "Cil":
                audiosoruce.PlayOneShot(C2sound);
                break;


        }
    }

}
