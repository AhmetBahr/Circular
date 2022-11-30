using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RandomColor : MonoBehaviour
{
    float randomNuber;
    private Renderer _renderer;
    private int materialCount;
    public Gradient SourceGradient;
    private int GradientColorKeyCount;






    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        materialCount = _renderer.materials.Length;
        GradientColorKeyCount = SourceGradient.colorKeys.Length;
        //RandomColors();

  
    }

    void Update()
    {


    }

    public void RandomColors()
    {
        for(int i = 0;i< materialCount; i++)
        {
            _renderer.materials[i].color = SourceGradient.colorKeys[Random.Range(0, GradientColorKeyCount)].color;
           // _renderer.materials[i].color = SourceGradient.Evaluate(Random.Range(0f, 1f));


        }


    }





}
