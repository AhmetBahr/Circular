using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPlayer : MonoBehaviour
{
    float timeCounter = 0;
    float speed = 1f;
    float width = 2f;
    float height = 2;
    int yon = 1;
    float yonD = 0;





    void Update()
    {
        if (yon == 1)
            timeCounter += Time.deltaTime * speed;

        if (yon == -1)
            timeCounter += Time.deltaTime * speed * -1;

        float x = Mathf.Cos(timeCounter) * width * 5 / 6;
        float y = Mathf.Sin(timeCounter) * height * 5 / 6;
        float z = 0;

        transform.position = new Vector3(x, y+1, 90);

        yonD += (int)Time.deltaTime + 1;
    

        if(yonD >= 5000)
        {
            yon *= -1;
            yonD = 0;
        }

    }
}
