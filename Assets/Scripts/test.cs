using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    bool green = true;
    bool blue = false;
    bool red = false;
    public Image image;
    float eTime = 0;
    float maxTime = 2;

    private void Update()
    {
        eTime += Time.deltaTime;

        if (green)
        {
            image.color = Color.green;
        }
        else if (blue)
        {
            image.color = Color.blue;
        }
        else 
        {
            image.color = Color.red;
        }

        if (eTime > maxTime)
        {
            testtest();
            eTime -= maxTime;
        }
        Debug.Log(eTime);

    }

    public void testtest()
    {
        if (green)
        {
            green = false;
            blue = true;
            return;
        }
        if (blue)
        {
            blue = false;
            red = true;
            return;

        }
        if (red)
        {
            red = false;
            green = true;
            return;
        }
    }
}
