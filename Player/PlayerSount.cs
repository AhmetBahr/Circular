using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSount : MonoBehaviour
{

    public static AudioClip point_sound, swing_sound,expo_sound;
    static AudioSource audiosoruce;

    void Start()
    {


        point_sound = Resources.Load<AudioClip>("bup_wav");
        swing_sound = Resources.Load<AudioClip>("Swing");
        expo_sound = Resources.Load<AudioClip>("expo");

        audiosoruce = GetComponent<AudioSource>();

    }

    public static void PlayerSound(string clip)
    {

        switch (clip)
        {
            case "point":
               audiosoruce.PlayOneShot(point_sound);
                Debug.Log("Point");
                break;
            case "swing":
               audiosoruce.PlayOneShot(swing_sound);
               Debug.Log("swing");
                break;
            case "expoo":
                audiosoruce.PlayOneShot(expo_sound);
                Debug.Log("expo");
                break;




        }
    }

}