using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tail : MonoBehaviour
{

    public TrailRenderer trRen;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            AddTail();
        }
    }

    public void AddTail()
    {

        trRen.time += 0.5f;
    }

}
