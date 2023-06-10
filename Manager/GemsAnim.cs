using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemsAnim : MonoBehaviour
{
    [Header("Animation")]
    public Animator Gems_Anim;

    private void Start()
    {
        Gems_Anim = GetComponent<Animator>();

    }

    public void AnimMove()
    {
        Gems_Anim.SetTrigger("Start");

    }

}
