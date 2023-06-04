using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapAnimation : MonoBehaviour
{
    [Header("Animation")]
    public Animator anim_Tap;
    private float animStartTime = 8;
    
    
    
    private void Start()
    {
        anim_Tap = GetComponent<Animator>();
       // animStartTime = 7;

        anim_Tap.SetTrigger("start");

    }

    private void Update()
    {
        animController();


    }

    private void animController()
    {
        if (animStartTime <= 0)
        {

            anim_Tap.SetTrigger("move");

        }

        animStartTime -= Time.deltaTime;
    }
}
