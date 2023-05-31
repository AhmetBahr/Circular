using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Player_Rotation : MonoBehaviour
{


    [SerializeField] private GameObject point;
    private float speed = 1.5f;


    private float xAngle, yAngle, zAngle;


    void Update()
    {
        point.transform.DORotate(new Vector3(0, 0, zAngle + 45), 1, RotateMode.WorldAxisAdd);

    }



}
